using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Places;
using MallorcaTeslas.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Infrastructure.Repositories.Places;

public class PlacesRepository(MallorcaTeslasDatabaseContext context) : IPlacesRepository
{
    private readonly MallorcaTeslasDatabaseContext _context = context;

    public async Task<Place?> GetPlaceById(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Places.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Place>> GetPlaces(CancellationToken cancellationToken = default)
    {
        return await _context.Places.ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}
