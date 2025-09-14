using MediatR;
namespace RealEstate.Application.Auth.Commands.Login
{
    public record LoginCommand(
       string Username,
       string Password
) : IRequest<Result<string>>;
}
