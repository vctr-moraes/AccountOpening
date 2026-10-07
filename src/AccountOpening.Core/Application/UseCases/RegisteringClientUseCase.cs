using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases
{
    public sealed class RegisteringClientUseCase(IClientRepository clientRepository, IAgencyRepository agencyRepository) :
        UseCase<RegisterClientRequestDto, RegisterClientResponseDto>
    {
        protected override async Task<RegisterClientResponseDto> ExecuteAsync(RegisterClientRequestDto registerClientRequest)
        {
            var agency = await agencyRepository.GetDefaultAgency();
            
            var client = new Client(
                registerClientRequest.Name,
                registerClientRequest.DateOfBirth,
                registerClientRequest.Document,
                agency);
            
            var account = new Account(client, client.Id);
            
            agency.AssociateClient(client);
            
            client.AssociateAccount(account);

            clientRepository.Add(client);

            return new RegisterClientResponseDto
            {
                Greetings = $"Hello {client.Name}, your account {account.AccountType} has been successfully created!"
            };
        }
    }
}
