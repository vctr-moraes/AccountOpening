using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public sealed class GetClientsUseCase(IClientRepository clientRepository) :
    UseCase<GetClientsRequestDto, GetClientsResponseDto>
{
    protected override async Task<GetClientsResponseDto> ExecuteAsync(GetClientsRequestDto request)
    {
        var clients = await clientRepository.GetAll();

        var response = new GetClientsResponseDto
        {
            ClientData = clients.Select(c => new ClientData
            {
                Id = c.Id,
                Name = c.Name,
                DateOfBirth = c.DateOfBirth,
                Document = c.Document,
                IsActive = c.IsActive
            }).ToList()
        };

        return response;
    }
}