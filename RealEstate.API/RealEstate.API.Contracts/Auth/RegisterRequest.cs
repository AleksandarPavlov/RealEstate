
namespace RealEstate.API.Contracts.Auth
{
    public record RegisterRequest
       (
         string FullName,
         string ContactNumber,
         string? EmailAddress,
         string? SocialMediaLink,
         string Username,
         string Password           
       );
}
