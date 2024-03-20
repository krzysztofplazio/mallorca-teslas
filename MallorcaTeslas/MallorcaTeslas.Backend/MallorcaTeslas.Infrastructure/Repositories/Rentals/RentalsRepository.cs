using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Dtos.Rentals;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Rentals;
using MallorcaTeslas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MallorcaTeslas.Infrastructure.Extentions;

namespace MallorcaTeslas.Infrastructure.Repositories.Rentals;

public class RentalsRepository(MallorcaTeslasDatabaseContext context) : IRentalsRepository
{
    private readonly MallorcaTeslasDatabaseContext _context = context;

    public async Task CreateRental(Rental rental, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(rental, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Rental>> GetRentalsByDates(DateTime from, DateTime to, CancellationToken cancellationToken = default)
    {
        return await _context.Rentals.Where(y => y.From <= from && y.From <= to
                                                    && y.To > from && y.To >= to
                                             || y.From > from && y.From < to
                                                    && y.To > from && y.To >= to
                                             || y.From <= from && y.From <= to
                                                    && y.To > from && y.To <= to
                                             || y.From > from && y.From < to
                                                    && y.To > from && y.To < to).ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<PagedItems<Rental>> GetRetnals(string? order, Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var baseQuery = _context.Rentals
            .Include(x => x.BorrowPlace)
            .Include(x => x.ReturnPlace)
            .Include(x => x.Customer)
            .Include(x => x.Car)
            .Where(x => x.Customer.UserId == userId);
        
        if (order is not null)
        {
            baseQuery = baseQuery.OrderBy(order);
        }

        return await baseQuery.ToPaginatedListAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
    }
}
