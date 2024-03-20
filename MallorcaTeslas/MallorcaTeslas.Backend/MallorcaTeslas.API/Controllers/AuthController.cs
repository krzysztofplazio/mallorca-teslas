using System.Globalization;
using MallorcaTeslas.Application.Commands.Auth.Login;
using MallorcaTeslas.Application.Commands.Users.CreateUser;
using MallorcaTeslas.Application.Dtos.Authentication;
using MallorcaTeslas.Application.Dtos.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslas.API.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync([FromBody] LoginModel user, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new LoginCommand(user.Username, user.Password), cancellationToken);
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest, CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(new CreateUserCommand(registerUserRequest), cancellationToken: cancellationToken);
        return Created(string.Create(CultureInfo.InvariantCulture, $"/api/users/{id}"), value: null);
    }

    [HttpDelete("logout"), Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }
}