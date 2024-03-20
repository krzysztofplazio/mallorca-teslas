using MallorcaTeslas.Core.Dtos.Places;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallorcaTeslas.Application.Queries.Places.GetPlaces;

public class GetPlacesQuery : IRequest<IEnumerable<PlaceDto>>
{
}
