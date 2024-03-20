using MallorcaTeslas.Application.Dtos.Users;
using MediatR;

namespace MallorcaTeslas.Application.Queries.Users.GetUserByUsername;

public class GetUserByUsernameQuery(string username) : IRequest<UserDto>
{
    public string Username { get; } = username;
}