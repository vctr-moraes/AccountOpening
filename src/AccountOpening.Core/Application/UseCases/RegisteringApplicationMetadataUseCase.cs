using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Enums;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public sealed class RegisteringApplicationMetadataUseCase(IClientRepository clientRepository) :
    UseCase<RegisterApplicationMetadataRequestDto, OpenAccountResponseDto>
{
    protected override async Task<OpenAccountResponseDto> ExecuteAsync(RegisterApplicationMetadataRequestDto request)
    {
        var client = await clientRepository.GetById(request.ClientId) ?? throw new Exception("Client not found");

        var applicationMetadata = new ApplicationMetadata(request.TransactionalPassword, client);
        
        var account = client.Accounts
            .FirstOrDefault(a => a.AccountStatus == AccountStatus.OpeningRequested) ??
                throw new Exception("No account found with status OpeningRequested");
        
        client.AssociateApplicationMetadata(applicationMetadata, account);
        
        clientRepository.AddApplicationMetadata(applicationMetadata);
        
        return new OpenAccountResponseDto
        {
            AccountType = account.AccountType.ToString(),
            AccountNumber = account.AccountNumber,
            ClientName = client.Name
        };
    }
}