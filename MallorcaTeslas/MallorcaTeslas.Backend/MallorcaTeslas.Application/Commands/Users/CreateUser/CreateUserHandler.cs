using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using MallorcaTeslas.Core.Repositories.Users;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Application.Exceptions.Users;
using MallorcaTeslas.Application.Constants.Users;

namespace MallorcaTeslas.Application.Commands.Users.CreateUser;

public class CreateUserHandler(IUsersRepository usersRepository,
                               IMapper mapper,
                               IPasswordHasher<User> passwordHasher,
                               IConfiguration configuration) : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly IConfiguration _configuration = configuration;

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _usersRepository.GetUserByUsername(request.RegisterUserRequest.Username, cancellationToken).ConfigureAwait(false) is not null)
        {
            throw new UsernameTakenException(UserExceptionErrorCodes.UsernameTaken);
        }

        var user = _mapper.Map<User>(request.RegisterUserRequest);
        user.Password = Encoding.UTF8.GetBytes(_passwordHasher.HashPassword(user, request.RegisterUserRequest.Password));

        await _usersRepository.InsertUser(user, cancellationToken).ConfigureAwait(false);
        return user.Id;
    }
}