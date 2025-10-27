using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Contracts.Error;
using RealEstate.API.Contracts.Property;
using RealEstate.Application.Property.Commands.ChangeStatus;
using RealEstate.Application.Property.Commands.CreateApartment;
using RealEstate.Application.Property.Commands.CreateHouse;
using RealEstate.Application.Property.Commands.GenerateDescription;
using RealEstate.Application.Property.Queries.FetchLatestProperties;
using RealEstate.Application.Property.Queries.FetchMyAdvertisements;
using RealEstate.Application.Property.Queries.FetchPropertiesByFilters;
using RealEstate.Application.Property.Queries.FetchPropertiesForApproval;
using RealEstate.Application.Property.Queries.FetchPropertyById;
using RealEstate.Application.Property.Queries.FindNearbyProperties;
using System.Security.Claims;

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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateApartmentAsync([FromForm] CreateApartmentRequest apartmentRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new ErrorResponse("Authentication", "Invalid token."));
            }

            var result = await _mediator.Send(new CreateApartmentCommand
            (
             apartmentRequest.Name,
             apartmentRequest.ListingType,
             apartmentRequest.City,
             apartmentRequest.Address,
             apartmentRequest.Price,
             apartmentRequest.SizeInMmSquared,
             apartmentRequest.IsPremium,
             username,
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateHouseAsync([FromForm] CreateHouseRequest houseRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new ErrorResponse("Authentication", "Invalid token."));
            }

            var result = await _mediator.Send(new CreateHouseCommand
            (
             houseRequest.Name,
             houseRequest.ListingType,
             houseRequest.City,
             houseRequest.Address,
             houseRequest.Price,
             houseRequest.SizeInMmSquared,
             houseRequest.IsPremium,      
             username,
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateLandAsync([FromForm] CreateLandRequest landRequest, [FromForm] IEnumerable<IFormFile>? images, CancellationToken cancellationToken)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new ErrorResponse("Authentication", "Invalid token."));
            }

            var result = await _mediator.Send(new CreateLandCommand
            (
             landRequest.Name,
             landRequest.ListingType,
             landRequest.City,
             landRequest.Address,
             landRequest.Price,
             landRequest.SizeInMmSquared,
             landRequest.IsPremium,
             username,
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
                    findNearbyRequest.Distance,
                    findNearbyRequest.ListingType));

            return result.Match<ActionResult>(
                success => Ok(success.Select(property => PropertyResponseExtensions.ToContract(property)).ToList()),
                failure => NotFound(new ErrorResponse(failure.Code, failure.Description))
            );
        }
        
        [HttpPost("generate-description")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult<string?>> GenerateDescriptionAsync([FromBody] GenerateDescriptionRequest descriptionRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GenerateDescriptionCommand
            (
                descriptionRequest.PropertyType,
                descriptionRequest.ListingType,
                descriptionRequest.Size,
                descriptionRequest.Address
            ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpPost("change-status/{id}")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> ChangePropertyStatus(long id, [FromBody] ChangePropertyStatusRequest changePropertyStatusRequest, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new ChangePropertyStatusCommand
            (
                id,
                changePropertyStatusRequest.Status
            ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpGet("waiting-approval")]
        [ActionName(nameof(GetWaitingForApprovalAsync))]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyResponse>))]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetWaitingForApprovalAsync(
        [FromQuery] PropertiesForApprovalRequest propertiesForApprovalRequest)
        {
            var result = await _mediator
                .Send(new FetchPropertiesForApprovalQuery
                (
                    propertiesForApprovalRequest.Page,
                    propertiesForApprovalRequest.PageSize
                ));

            return result.Match<ActionResult>(
                success => Ok(success.Select(property => PropertyResponseExtensions.ToContract(property)).ToList()),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }

        [HttpGet("my-adds")]
        [ActionName(nameof(GetMyAdvertisementsAsync))]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PropertyResponse>))]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetMyAdvertisementsAsync([FromQuery] PropertiesForApprovalRequest propertiesForApprovalRequest)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new ErrorResponse("Authentication", "Invalid token."));
            }

            var result = await _mediator
                .Send(new FetchMyAdvertisementsQuery
                (
                    username,
                    propertiesForApprovalRequest.Page,
                    propertiesForApprovalRequest.PageSize

                ));

            return result.Match<ActionResult>(
                success => Ok(success.Select(property => PropertyResponseExtensions.ToContract(property)).ToList()),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );
        }
    }
}

