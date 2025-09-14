
using MediatR;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Domain.Persistance;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
using RealEstate.Domain.Common.Errors;
using Microsoft.AspNetCore.Identity;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace RealEstate.Application.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IAdvertiserReadRepository _advertiserReadRepository;
        private readonly IConfiguration _config;

        public LoginCommandHandler(IAdvertiserReadRepository advertiserReadRepository, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _advertiserReadRepository = advertiserReadRepository;
            _config = config;
        }
        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var advertiserResult = await _advertiserReadRepository.FetchAdvertiserByUsername(request.Username);

            if (advertiserResult.IsFailure)
            {
               return Result<string>.Failure(new Error("Authentication", "Username or Password is incorrect."));
            }

            var user = advertiserResult.Value;

            var passwordHasher = new PasswordHasher<object>();

            var passwordResult = passwordHasher.VerifyHashedPassword(null!, user.Password, request.Password);

            if (passwordResult != PasswordVerificationResult.Success) 
            {
                return Result<string>.Failure(new Error("Authentication", "Username or Password is incorrect."));
            }

            return GenerateJwtToken(user);
        }

        private Result<string> GenerateJwtToken(DomainAdvertiser user)
        {
            try
            {
                var jwtSettings = _config.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim("userId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(double.Parse(jwtSettings["ExpireHours"])),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Result<string>.Success(tokenString);
            }
            catch (Exception)
            {
                return Result<string>.Failure(new Error("JWT", "Failed to generate token"));
            }
        }
    }
}
