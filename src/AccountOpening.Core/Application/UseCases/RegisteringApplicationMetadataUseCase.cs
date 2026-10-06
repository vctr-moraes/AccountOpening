using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Enums;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases;

public sealed class RegisteringApplicationMetadataUseCase(IClientRepository clientRepository) :
    UseCase<RegisterApplicationMetadataRequestDto, RegisterApplicationMetadataResponseDto>
{
    protected override async Task<RegisterApplicationMetadataResponseDto> ExecuteAsync(RegisterApplicationMetadataRequestDto request)
    {
        var client = await clientRepository.GetById(request.ClientId) ?? throw new Exception("Client not found");
        
        var account = client.Accounts
            .FirstOrDefault(a => a.AccountStatus == AccountStatus.OpeningRequested) ??
                throw new Exception("No account found with status OpeningRequested");

        var applicationMetadata = new ApplicationMetadata(request.TransactionalPassword, client);
        
        client.AssociateApplicationMetadata(applicationMetadata, account);
        
        clientRepository.AddApplicationMetadata(applicationMetadata);
        
        return new RegisterApplicationMetadataResponseDto
        {
            AccountType = account.AccountType.ToString(),
            AccountNumber = account.AccountNumber,
            ClientName = client.Name
        };
    }
}