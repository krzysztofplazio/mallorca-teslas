using MediatR;


namespace MallorcaTeslas.Application.Commands.Auth.Login;

public class LoginCommand(string? username, string? password) : IRequest
{
    public string? Username { get; } = username;
    public string? Password { get; } = password;
}