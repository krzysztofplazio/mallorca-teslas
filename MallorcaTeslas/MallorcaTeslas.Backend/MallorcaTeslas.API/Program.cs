using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using MallorcaTeslas.Application.Commands.Rentals;
using MallorcaTeslas.Application.Dtos.Authentication;
using MallorcaTeslas.Application.Dtos.Users;
using MallorcaTeslas.Application.Exceptions.Cars;
using MallorcaTeslas.Application.Exceptions.Users;
using MallorcaTeslas.Application.ProblemDetails.Users;
using MallorcaTeslas.Application.Validators.Auth;
using MallorcaTeslas.Application.Validators.Rentals;
using MallorcaTeslas.Application.Validators.Users;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Cars;
using MallorcaTeslas.Core.Repositories.Customers;
using MallorcaTeslas.Core.Repositories.Places;
using MallorcaTeslas.Core.Repositories.Rentals;
using MallorcaTeslas.Core.Repositories.Users;
using MallorcaTeslas.Infrastructure.Contexts;
using MallorcaTeslas.Infrastructure.Repositories.Cars;
using MallorcaTeslas.Infrastructure.Repositories.Customers;
using MallorcaTeslas.Infrastructure.Repositories.Places;
using MallorcaTeslas.Infrastructure.Repositories.Rentals;
using MallorcaTeslas.Infrastructure.Repositories.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;

const string AppCorsPolicy = "_appCorsPolicy";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(setup =>
{
    setup.IncludeExceptionDetails = (_, _) =>
           builder.Environment.IsDevelopment()
        || builder.Environment.IsStaging();
    setup.Map<UserException>(ex => new UserExceptionDetails(ex));
    setup.Map<CarException>(ex => new CarExceptionDetails(ex));
});

builder.Host.UseSerilog((ctx, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(ctx.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("MallorcaTeslas.API", typeof(Program).Assembly.GetName().Name)
        .Enrich.WithProperty("Environment", ctx.HostingEnvironment);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AppCorsPolicy,
                      policy =>
                      {
                          policy.SetIsOriginAllowed(_ => true);
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowCredentials();
                      });
});

builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
})
.AddJsonOptions(options =>
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
// Validators
builder.Services.AddScoped<IValidator<LoginModel>, LoginModelValidator>();
builder.Services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserRequestValidator>();
builder.Services.AddScoped<IValidator<CreateRentalCommand>, CreateRentalValidator>();

// Repositories 
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<IPlacesRepository, PlacesRepository>();
builder.Services.AddScoped<IRentalsRepository, RentalsRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

// Services
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddHttpContextAccessor();

var assembly = Assembly.Load("MallorcaTeslas.Application");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MallorcaTeslasDatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MallorcaTeslasDatabase"),
                      conf => conf.MigrationsAssembly("MallorcaTeslas.Infrastructure"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "COOKIE";
    options.DefaultChallengeScheme = "COOKIE";
})
.AddCookie(options =>
{
    options.LoginPath = "/api/auth/login";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.Events.OnRedirectToAccessDenied = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToLogin = (context) =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
})
.AddPolicyScheme("COOKIE", "COOKIE", options =>
{
    options.ForwardDefaultSelector = context =>
    {
        return CookieAuthenticationDefaults.AuthenticationScheme;
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors(AppCorsPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
