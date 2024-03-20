using MallorcaTeslas.Application.Queries.Places.GetPlaceById;
using MallorcaTeslas.Application.Queries.Places.GetPlaces;
using MallorcaTeslas.Core.Dtos.Places;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace MallorcaTeslas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PlacesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<PlaceDto>> GetPlaces(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetPlacesQuery(), cancellationToken);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceById(int id, CancellationToken cancellationToken = default)
        {
            var place = await _mediator.Send(new GetPlaceByIdQuery(id), cancellationToken);
            if (place is null)
            {
                return NotFound();
            }

            return Ok(place);
        }
    }
}
