using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Dtos.Rentals;
using MallorcaTeslas.Core.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Core.Repositories.Rentals;

public interface IRentalsRepository
{
    Task<IEnumerable<Rental>> GetRentalsByDates(DateTime from, DateTime to, CancellationToken cancellationToken = default);
    Task CreateRental(Rental rental, CancellationToken cancellationToken = default);
    Task<PagedItems<Rental>> GetRetnals(string? order, Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}
