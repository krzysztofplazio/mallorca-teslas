using AutoMapper;
using MallorcaTeslas.Core.Dtos.Places;
using MallorcaTeslas.Core.Repositories.Places;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Places.GetPlaces;

public class GetPlacesHandler(IMapper mapper, IPlacesRepository placesRepository) : IRequestHandler<GetPlacesQuery, IEnumerable<PlaceDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPlacesRepository _placesRepository = placesRepository;

    public async Task<IEnumerable<PlaceDto>> Handle(GetPlacesQuery request, CancellationToken cancellationToken)
    {
        var places = await _placesRepository.GetPlaces(cancellationToken).ConfigureAwait(false);
        return _mapper.Map<IEnumerable<PlaceDto>>(places);
    }
}
