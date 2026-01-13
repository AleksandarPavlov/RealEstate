using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Contracts.Auth;
using RealEstate.API.Contracts.Error;
using RealEstate.Application.Auth.Commands.Login;
using RealEstate.Application.Auth.Commands.Register;

namespace RealEstate.API.Controllers
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;
        public AuthController(ISender mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> Register([FromBody] RegisterRequest registerRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new RegisterCommand
            (
                registerRequest.FullName,
                registerRequest.ContactNumber,
                registerRequest.EmailAddress,
                registerRequest.SocialMediaLink,
                registerRequest.Username,
                registerRequest.Password
            ),  cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new LoginCommand
            (
                loginRequest.Username,
                loginRequest.Password
            ),  cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }
    }
}
