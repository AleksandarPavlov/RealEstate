
using MediatR;
using RealEstate.Domain.Persistance;
using RealEstate.Domain.Persistance.Write;

namespace RealEstate.Application.Property.Commands.ChangeStatus
{
    public class ChangePropertyStatusCommandHandler : IRequestHandler<ChangePropertyStatusCommand, Result<Unit>>
    {
        private readonly IPropertyWriteRepository _propertyWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePropertyStatusCommandHandler(IPropertyWriteRepository propertyWriteRepository, IUnitOfWork unitOfWork)
        {
            _propertyWriteRepository = propertyWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit>> Handle(ChangePropertyStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _propertyWriteRepository.ChangeStatus(request.Status, request.Id);

            if (result.IsFailure)
                return Result<Unit>.Failure(result.Error);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
