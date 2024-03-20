using MallorcaTeslas.Core.Models;

namespace MallorcaTeslas.Core.Repositories.Users;

public interface IUsersRepository
{
    Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken = default);
    Task InsertUser(User user, CancellationToken cancellationToken = default);
    Task UpdateUser(User user, CancellationToken cancellationToken = default);
    Task<Dtos.Paginations.PagedItems<User>> GetUsers(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}