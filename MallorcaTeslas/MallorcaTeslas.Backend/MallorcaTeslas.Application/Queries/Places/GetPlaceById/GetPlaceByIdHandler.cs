using AutoMapper;
using MallorcaTeslas.Core.Dtos.Places;
using MallorcaTeslas.Core.Repositories.Places;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Places.GetPlaceById;

public class GetPlaceByIdHandler(IMapper mapper, IPlacesRepository placesRepository) : IRequestHandler<GetPlaceByIdQuery, PlaceDto?>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPlacesRepository _placesRepository = placesRepository;

    public async Task<PlaceDto?> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var place = await _placesRepository.GetPlaceById(request.Id, cancellationToken).ConfigureAwait(false);
        return _mapper.Map<PlaceDto?>(place);
    }
}
