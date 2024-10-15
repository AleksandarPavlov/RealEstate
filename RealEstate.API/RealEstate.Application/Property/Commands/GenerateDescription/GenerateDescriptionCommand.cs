using MediatR;
using RealEstate.Domain.Common.Enums;

namespace RealEstate.Application.Property.Commands.GenerateDescription;

    public record GenerateDescriptionCommand(
        PropertyType PropertyType,
        PropertyListingType ListingType,
        string Size,
        string Address
    ) : IRequest<Result<string?>>;