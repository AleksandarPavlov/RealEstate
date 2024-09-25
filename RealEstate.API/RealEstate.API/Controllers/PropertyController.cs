using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Contracts.Error;
using RealEstate.API.Contracts.Property;
using RealEstate.Application.Property.Commands.CreateApartment;
using RealEstate.Application.Property.Commands.CreateHouse;
using RealEstate.Application.Property.Queries.FetchPropertiesByFilters;

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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateApartmentAsync([FromForm] CreateApartmentRequest apartmentRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateApartmentCommand
            (
             apartmentRequest.Name,
             apartmentRequest.ListingType,
             apartmentRequest.City,
             apartmentRequest.Address,
             apartmentRequest.Price,
             apartmentRequest.SizeInMmSquared,
             apartmentRequest.IsPremium,
             apartmentRequest.IsFurnished,
             apartmentRequest.FloorNumber,
             apartmentRequest.NumberOfRooms,
             images
             ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success), 
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );

        }

        [HttpPost("create-house")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateHouseAsync([FromBody] CreateHouseRequest houseRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateHouseCommand
            (
             houseRequest.Name,
             houseRequest.ListingType,
             houseRequest.City,
             houseRequest.Address,
             houseRequest.Price,
             houseRequest.SizeInMmSquared,
             houseRequest.IsPremium,
             houseRequest.IsFurnished,
             houseRequest.FloorNumber,
             houseRequest.NumberOfRooms,
             images
             ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpPost("create-land")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateLandAsync([FromBody] CreateLandRequest landRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateLandCommand
            (
             landRequest.Name,
             landRequest.ListingType,
             landRequest.City,
             landRequest.Address,
             landRequest.Price,
             landRequest.SizeInMmSquared,
             landRequest.IsPremium,
             images
             ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpGet]
        [ActionName(nameof(GetByQueryParamsAsync))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyResponse>))]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetByQueryParamsAsync(
        [FromQuery] PropertiesByFilterRequest propertiesByFilterRequest)
        {
            var result = await _mediator
                .Send(new FetchPropertiesByFiltersQuery
                (
                    propertiesByFilterRequest.City,
                    propertiesByFilterRequest.ListingType,
                    propertiesByFilterRequest.PropertyType,
                    propertiesByFilterRequest.SizeFrom,
                    propertiesByFilterRequest.PriceTo,
                    propertiesByFilterRequest.GroundFloor,
                    propertiesByFilterRequest.NumberOfRooms,
                    propertiesByFilterRequest.Page,
                    propertiesByFilterRequest.PageSize
                ));

            return result.Match<ActionResult>(
                success => Ok(success.Select(property => PropertyResponseExtensions.ToContract(property)).ToList()),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }
    }
}

