using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RealEstate.API.Contracts.Error;
using RealEstate.API.Contracts.Property;
using RealEstate.Application.Property.Commands.CreateApartment;
using RealEstate.Application.Property.Commands.CreateHouse;

namespace RealEstate.API.Controllers
{
    [Route("property")]
    public class PropertyController : ControllerBase
    {
        private readonly ISender _mediator;
        public PropertyController(ISender mediator) 
        { 
            _mediator = mediator;
        
        } 

        [HttpPost("create-apartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateApartmentAsync([FromBody] CreateApartmentRequest apartmentRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateApartmentCommand
            (
             apartmentRequest.Name,
             apartmentRequest.ListingType,
             apartmentRequest.Location,
             apartmentRequest.Price,
             apartmentRequest.SizeInMmSquared,
             apartmentRequest.IsPremium,
             apartmentRequest.IsFurnished,
             apartmentRequest.FloorNumber,
             apartmentRequest.NumberOfRooms
         ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success), 
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );

        }

        [HttpPost("create-house")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateHouseAsync([FromBody] CreateHouseRequest houseRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateHouseCommand
            (
             houseRequest.Name,
             houseRequest.ListingType,
             houseRequest.Location,
             houseRequest.Price,
             houseRequest.SizeInMmSquared,
             houseRequest.IsPremium,
             houseRequest.IsFurnished,
             houseRequest.FloorNumber,
             houseRequest.NumberOfRooms
         ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpPost("create-land")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateLandAsync([FromBody] CreateLandRequest landRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateLandCommand
            (
             landRequest.Name,
             landRequest.ListingType,
             landRequest.Location,
             landRequest.Price,
             landRequest.SizeInMmSquared,
             landRequest.IsPremium
         ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

      /*  [HttpGet]
        [ActionName(nameof(GetByQueryParamsAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PropertyResponse>))]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetByQueryParamsAsync(
        [FromQuery] PropertiesByFilterRequest propertiesByFilterRequest)
        {
            return await _mediator
                .Send();
        }*/
    }
}

