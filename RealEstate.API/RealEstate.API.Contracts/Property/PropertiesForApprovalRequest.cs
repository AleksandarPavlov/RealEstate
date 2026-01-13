
namespace RealEstate.API.Contracts.Property
{
    public record PropertiesForApprovalRequest
    (
        int Page = 0,
        int PageSize = 10
    );
}
