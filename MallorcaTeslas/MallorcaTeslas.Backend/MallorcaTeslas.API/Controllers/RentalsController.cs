using MallorcaTeslas.Application.Commands.Rentals;
using MallorcaTeslas.Application.Queries.Rentals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentalsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] CreateRentalCommand rental, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(rental, cancellationToken);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersRentals(string? order, string? search, int pageNumber = 1, int pageSize = 15, CancellationToken cancellationToken = default)
        {
            var retnals = await _mediator.Send(new GetRentalsQuery(order, search, pageNumber, pageSize), cancellationToken);
            return Ok(retnals);
        }
    }
}
