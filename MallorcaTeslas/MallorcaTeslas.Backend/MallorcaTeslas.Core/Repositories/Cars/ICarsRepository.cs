using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Models;

namespace MallorcaTeslas.Core.Repositories.Cars;

public interface ICarsRepository
{
    Task<PagedItems<Car>> GetCarsByDates(DateTime from,
                                                  DateTime to,
                                                  int pageNumber,
                                                  int pageSize,
                                                  CancellationToken cancellationToken = default);

    Task<Car?> GetCarById(int id, CancellationToken cancellationToken = default);
}
