using AutoMapper;
using MallorcaTeslas.Application.Constants.Users;
using MallorcaTeslas.Application.Exceptions.Users;
using MallorcaTeslas.Core.Dtos.Paginations;
using MallorcaTeslas.Core.Dtos.Rentals;
using MallorcaTeslas.Core.Models;
using MallorcaTeslas.Core.Repositories.Rentals;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Rentals;

public class GetRentalsHandler(IMapper mapper, IRentalsRepository rentalsRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetRentalsQuery, PagedItems<GetRentalsReponse>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRentalsRepository _rentalsRepository = rentalsRepository;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<PagedItems<GetRentalsReponse>> Handle(GetRentalsQuery request, CancellationToken cancellationToken)
    {
        var userId = _httpContext.User.Claims
            .FirstOrDefault(x => string.Equals(x.Type, ClaimTypes.NameIdentifier, StringComparison.OrdinalIgnoreCase))?.Value ?? throw new UserHasNoIdentityException(UserExceptionErrorCodes.UserHasNoIdentity);
        var rentals = await _rentalsRepository.GetRetnals(request.Order, new Guid(userId), request.PageNumber, request.PageSize, cancellationToken).ConfigureAwait(false);
        return _mapper.Map<PagedItems<GetRentalsReponse>>(rentals);
    }
}
