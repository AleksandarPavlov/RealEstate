
using System.ComponentModel.DataAnnotations;

namespace RealEstate.API.Contracts.Error
{
    public record ErrorResponse
    {
        [Required]
        public string Code { get; }

        [Required]
        public string Error { get; }

        public ErrorResponse(string code, string error)
        {
            Code = code;
            Error = error;
        }
    }
}
