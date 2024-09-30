using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Contracts.Coordinates;
using RealEstate.API.Contracts.Error;
using RealEstate.API.Contracts.Property;
using RealEstate.Application.Property.Commands.CreateApartment;
using RealEstate.Application.Property.Commands.CreateHouse;
using RealEstate.Application.Property.Queries.FetchLatestProperties;
using RealEstate.Application.Property.Queries.FetchPropertiesByFilters;
using RealEstate.Application.Property.Queries.FetchPropertyById;
using RealEstate.Application.Property.Queries.FindNearbyProperties;

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
             images,
             apartmentRequest.Description
             ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success), 
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );

        }

        [HttpPost("create-house")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateHouseAsync([FromForm] CreateHouseRequest houseRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
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
             images,
             houseRequest.Description
             ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpPost("create-land")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateLandAsync([FromForm] CreateLandRequest landRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
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
             images,
             landRequest.Description
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

        [HttpGet("{id}")]
        [ActionName(nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyResponse))]
        public async Task<ActionResult<PropertyResponse>> GetById(long id)
        {
            var result = await _mediator
                .Send(new FetchPropertyByIdQuery(id));

            return result.Match<ActionResult>(
                success => Ok(PropertyResponseExtensions.ToContract(success)),
                failure => NotFound(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpGet("latest/{amount}")]
        [ActionName(nameof(GetLatest))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyResponse>))]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetLatest(int amount)
        {
            var result = await _mediator
                .Send(new FetchLatestPropertiesQuery(amount));

            return result.Match<ActionResult>(
                success => Ok(success.Select(property => PropertyResponseExtensions.ToContract(property)).ToList()),
                failure => NotFound(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpGet("find-nearby")]
        [ActionName(nameof(FindNearbyProperties))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyResponse>))]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> FindNearbyProperties([FromQuery] FindNearbyPropertiesRequest findNearbyRequest)
        {
            var result = await _mediator
                .Send(new FindNearbyPropertiesQuery(
                    findNearbyRequest.Lat, 
                    findNearbyRequest.Lon, 
                    findNearbyRequest.Distance));

            return result.Match<ActionResult>(
                success => Ok(success.Select(property => PropertyResponseExtensions.ToContract(property)).ToList()),
                failure => NotFound(new ErrorResponse(failure.Code, failure.Description))
            );
        }
    }
}

