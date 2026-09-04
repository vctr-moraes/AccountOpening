using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public sealed class RegisteringAddressUseCase(IClientRepository clientRepository) :
    UseCase<RegisterAddressRequestDto, RegisterAddressResponseDto>
{
    protected override async Task<RegisterAddressResponseDto> ExecuteAsync(RegisterAddressRequestDto request)
    {
        var client = await clientRepository.GetById(request.ClientId);

        if (client is null)
        {
            throw new Exception("Client not found");
        }

        var address = new Address(request.City, request.State, request.ZipCode, client);
        
        client.AssociateAddress(address);

        clientRepository.Update(client);
        clientRepository.AddAddress(address);

        return new RegisterAddressResponseDto();
    }
}