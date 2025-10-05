
using MediatR;
using RealEstate.Domain.Common.Enums;

namespace RealEstate.Application.Property.Commands.ChangeStatus
{
    public record ChangePropertyStatusCommand
    (
        long Id,
        PropertyStatus Status

    ) : IRequest<Result<Unit>>;
}
