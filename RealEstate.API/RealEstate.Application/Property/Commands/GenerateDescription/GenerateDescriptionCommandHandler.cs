using MediatR;
using RealEstate.Domain.Services;

namespace RealEstate.Application.Property.Commands.GenerateDescription;

public class GenerateDescriptionCommandHandler: IRequestHandler<GenerateDescriptionCommand, Result<string?>>
{
    private readonly IOpenAiService _openAiService;

    public GenerateDescriptionCommandHandler(IOpenAiService openAiService)
    {
        _openAiService = openAiService;
    }

    public async Task<Result<string?>> Handle(GenerateDescriptionCommand request, CancellationToken cancellationToken)
    {
        return await _openAiService.GeneratePropertyDescription(request.Address, request.Size, request.ListingType,
            request.PropertyType);
    }
    
}