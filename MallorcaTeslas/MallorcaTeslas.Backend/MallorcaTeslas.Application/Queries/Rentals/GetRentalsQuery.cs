using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Dtos.Rentals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Rentals;

public class GetRentalsQuery(string? order, string? search, int pageNumber, int pageSize) : IRequest<PagedItems<GetRentalsReponse>>
{
    public string? Order { get; } = order;
    public string? Search { get; } = search;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}
