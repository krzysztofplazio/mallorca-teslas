using MallorcaTeslas.Application.Dtos.Users;
using MediatR;

namespace MallorcaTeslas.Application.Commands.Users.CreateUser;

public class CreateUserCommand(RegisterUserRequest registerUserRequest) : IRequest<Guid>
{
    public RegisterUserRequest RegisterUserRequest { get; } = registerUserRequest;
}