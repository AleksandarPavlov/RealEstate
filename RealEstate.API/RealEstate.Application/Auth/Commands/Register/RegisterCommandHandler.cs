using MediatR;
using RealEstate.Domain.Persistance.Write;
using RealEstate.Domain.Persistance;
using DomainAdvertiser = RealEstate.Domain.Advertiser.Advertiser;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Persistance.Read;
using RealEstate.Domain.Common.Errors;
using RealEstate.Domain.Common.Enums;

namespace RealEstate.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<DomainAdvertiser>>
    {
        private readonly IAdvertiserWriteRepository _advertiserWriteRepository;
        private readonly IAdvertiserReadRepository _advertiserReadRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterCommandHandler(IAdvertiserWriteRepository advertiserWriteRepository, IAdvertiserReadRepository advertiserReadRepository, IUnitOfWork unitOfWork)
        {
            _advertiserWriteRepository = advertiserWriteRepository;
            _advertiserReadRepository = advertiserReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DomainAdvertiser>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingAdvertiserResult = await _advertiserReadRepository.FetchAdvertiserByUsername(request.Username);

            if (existingAdvertiserResult.IsSuccess)
            {
                return Result<DomainAdvertiser>.Failure(new Error("Advertiser", "Username already taken"));
            }

            var passwordHasher = new PasswordHasher<object>();

            var hashedPassword = passwordHasher.HashPassword(null!, request.Password);

            var advertiserResult = DomainAdvertiser.CreateAdvertiser(
                0,
                request.FullName,
                request.ContactNumber,
                request.EmailAddress,
                request.SocialMediaLink,
                request.Username,
                hashedPassword,
                Role.USER
            );

            return await advertiserResult.Match(
                async advertiser =>
                {
                  _advertiserWriteRepository.Add(advertiser);
                  await _unitOfWork.SaveChangesAsync(cancellationToken);
                  return Result<DomainAdvertiser>.Success(advertiser);
                  },
                  failure => Task.FromResult(Result<DomainAdvertiser>.Failure(failure))
              );

        }                                       
    }
}
