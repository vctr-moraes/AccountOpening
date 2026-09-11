using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public sealed class OpeningAccountUseCase(IClientRepository clientRepository) :
    UseCase<OpenAccountRequestDto, OpenAccountResponseDto>
{
    protected override async Task<OpenAccountResponseDto> ExecuteAsync(OpenAccountRequestDto input)
    {
        var client = await clientRepository.GetById(input.ClientId);
        
        if (client is null)
        {
            throw new Exception("Client not found");
        }
        
        var account = new Account(client, input.ClientId);
        
        client.AssociateAccount(account);
        
        clientRepository.Update(client);
        clientRepository.AddAccount(account);

        return new OpenAccountResponseDto();
    }
}