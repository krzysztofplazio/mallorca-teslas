using MallorcaTeslas.Application.Constants.Users;
using MallorcaTeslas.Application.Dtos.Users;
using MallorcaTeslas.Application.Exceptions.Users;
using MallorcaTeslas.Application.Queries.Users.GetUserByUsername;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;

namespace MallorcaTeslas.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken = default)
        {
            var username = HttpContext.User.Claims
                .FirstOrDefault(x => string.Equals(x.Type, ClaimTypes.Name, StringComparison.OrdinalIgnoreCase))?.Value ?? throw new UserHasNoIdentityException(UserExceptionErrorCodes.UserHasNoIdentity);
            var query = new GetUserByUsernameQuery(username);
            return Ok(await _mediator.Send(query, cancellationToken));
        }
    }
}
