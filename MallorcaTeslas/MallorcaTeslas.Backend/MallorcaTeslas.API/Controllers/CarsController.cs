using MallorcaTeslas.Application.Queries.Cars.GetCarById;
using MallorcaTeslas.Application.Queries.Cars.GetCarsByDates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CarsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
        [HttpGet]
        public async Task<IActionResult> GetCarsByDates(DateTime from,
                                                                 DateTime to,
                                                                 int pageNumber = 1,
                                                                 int pageSize = 15,
                                                                 CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetCarsByDatesQuery(from, to, pageNumber, pageSize), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id, CancellationToken cancellationToken = default)
        {
            var car = await _mediator.Send(new GetCarByIdQuery(id));
            if (car is null)
            {
                return NotFound();
            }

            return Ok(car);
        }
    }
}
