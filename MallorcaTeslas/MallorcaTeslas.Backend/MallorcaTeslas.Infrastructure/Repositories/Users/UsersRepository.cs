using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Users;
using MallorcaTeslas.Infrastructure.Contexts;
using MallorcaTeslas.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Repositories.Users;

public class UsersRepository(MallorcaTeslasDatabaseContext context) : IUsersRepository
{
    private readonly MallorcaTeslasDatabaseContext _context = context;

    public async Task<User?> GetUserByUsername(string username, CancellationToken cancellationToken = default)
                         => await _context.Users.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Username == username, cancellationToken).ConfigureAwait(false);

    public async Task InsertUser(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateUser(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<PagedItems<User>> GetUsers(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _context.Users.ToPaginatedListAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
    }
}
