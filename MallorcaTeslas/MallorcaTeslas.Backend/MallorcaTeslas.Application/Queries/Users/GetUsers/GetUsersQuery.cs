using MallorcaTeslas.Application.Dtos.Users;
using MallorcaTeslas.Core.Dtos.Paginations;
using MediatR;

namespace MallorcaTeslas.Application.Queries.Users.GetUsers;

public class GetUsersQuery(int pageNumber, int pageSize) : IRequest<PagedItems<UserDto>>
{
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}
