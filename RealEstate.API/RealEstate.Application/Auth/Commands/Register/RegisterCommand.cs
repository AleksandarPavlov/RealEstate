using MediatR;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;

namespace RealEstate.Application.Auth.Commands.Register
{
    public record RegisterCommand(
        string FullName,
        string ContactNumber,
        string? EmailAddress,
        string? SocialMediaLink,
        string Username,
        string Password
 ) : IRequest<Result<DomainAdvertiser>>;
}
