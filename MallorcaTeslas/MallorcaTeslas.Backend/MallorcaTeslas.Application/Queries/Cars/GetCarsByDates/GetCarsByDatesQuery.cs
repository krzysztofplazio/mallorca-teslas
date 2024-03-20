using MallorcaTeslas.Application.Dtos.Cars;
using MallorcaTeslas.Core.Dtos.Paginations;
using MediatR;

namespace MallorcaTeslas.Application.Queries.Cars.GetCarsByDates;

public class GetCarsByDatesQuery(DateTime from,
                                 DateTime to,
                                 int pageNumber,
                                 int pageSize) : IRequest<PagedItems<CarDto>>
{
    public DateTime From { get; } = from;
    public DateTime To { get; } = to;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}
