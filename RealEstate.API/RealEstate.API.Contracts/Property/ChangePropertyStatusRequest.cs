
using RealEstate.Domain.Common.Enums;

namespace RealEstate.API.Contracts.Property
{
    public record ChangePropertyStatusRequest
    (
        PropertyStatus Status
    );
}

