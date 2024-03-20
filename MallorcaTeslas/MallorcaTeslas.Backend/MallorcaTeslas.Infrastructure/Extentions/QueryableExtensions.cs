using MallorcaTeslas.Core.Dtos.Paginations;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslas.Infrastructure.Extentions;

public static class QueryableExtensions
{
    public static async Task<PagedItems<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync().ConfigureAwait(false);
        if (pageNumber > 1)
        {
            query = query.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize);
        }

        var items = await query
            .ToListAsync(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return new PagedItems<T>
        {
            Items = items,
            Page = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
        };
    }
}