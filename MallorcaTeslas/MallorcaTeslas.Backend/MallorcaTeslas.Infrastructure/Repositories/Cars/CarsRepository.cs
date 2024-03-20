using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Cars;
using MallorcaTeslas.Infrastructure.Contexts;
using MallorcaTeslas.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MallorcaTeslas.Infrastructure.Repositories.Cars;

public class CarsRepository(MallorcaTeslasDatabaseContext context) : ICarsRepository
{
    private readonly MallorcaTeslasDatabaseContext _context = context;

    public async Task<Car?> GetCarById(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Cars.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task<PagedItems<Car>> GetCarsByDates(DateTime from,
                                                                  DateTime to,
                                                                  int pageNumber,
                                                                  int pageSize,
                                                                  CancellationToken cancellationToken = default)
    {
        return await _context.Cars
                .Include(x => x.Rentals)
                .Where(x => !x.Rentals.Any(y => y.From <= from && y.From <= to
                                                    && y.To > from && y.To >= to
                                             || y.From > from && y.From < to
                                                    && y.To > from && y.To >= to
                                             || y.From <= from && y.From <= to
                                                    && y.To > from && y.To <= to
                                             || y.From > from && y.From < to
                                                    && y.To > from && y.To < to))
                .ToPaginatedListAsync(pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
    }
}
