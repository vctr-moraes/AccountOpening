using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public class RegisteringClientContactsUseCase(IClientRepository clientRepository) :
    UseCase<RegisterClientContactsRequestDto, RegisterClientContactsResponseDto>
{
    protected override async Task<RegisterClientContactsResponseDto> ExecuteAsync(RegisterClientContactsRequestDto request)
    {
        var client = await clientRepository.GetById(request.ClientId);

        if (client is null)
        {
            throw new Exception("Client not found");
        }

        client.AssociateContacts(request.PhoneNumber, request.Email);

        clientRepository.Update(client);

        return new RegisterClientContactsResponseDto();
    }
}