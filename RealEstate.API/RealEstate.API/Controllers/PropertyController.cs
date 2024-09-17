﻿using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Contracts.Error;
using RealEstate.API.Contracts.Property;
using RealEstate.Application.Property.Commands.CreateApartment;
using RealEstate.Application.Property.Commands.CreateHouse;

namespace RealEstate.API.Controllers
{
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
        public async Task<ActionResult> CreateApartmentAsync([FromBody] CreateApartmentRequest apartment, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateApartmentCommand
            (
             apartment.name,
             apartment.listingType,
             apartment.location,
             apartment.price,
             apartment.sizeInMmSquared,
             apartment.isFurnished,
             apartment.floorNumber,
             apartment.numberOfRooms
         ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success), 
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );

        }

        [HttpPost("create-house")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<ActionResult> CreateHouseAsync([FromBody] CreateHouseRequest house, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new CreateHouseCommand
            (
             house.name,
             house.listingType,
             house.location,
             house.price,
             house.sizeInMmSquared,
             house.isFurnished,
             house.floorNumber,
             house.numberOfRooms
         ), cancellationToken);

            return result.Match<ActionResult>(
                success => Ok(success),
                failure => BadRequest(new ErrorResponse(failure.Code, failure.Description))
            );

        }
    }
}
