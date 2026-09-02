using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public sealed class GetClientByIdUseCase(IClientRepository clientRepository) : UseCase<GetClientByIdRequestDto, GetClientByIdResponseDto>
{
    protected override async Task<GetClientByIdResponseDto> ExecuteAsync(GetClientByIdRequestDto request)
    {
        var client = await clientRepository.GetById(request.ClientId);

        if (client is null)
        {
            throw new Exception("Client not found");
        }

        return new GetClientByIdResponseDto{
            Id = client.Id,
            Name = client.Name,
            DateOfBirth = client.DateOfBirth,
            Document = client.Document
        };
    }
}