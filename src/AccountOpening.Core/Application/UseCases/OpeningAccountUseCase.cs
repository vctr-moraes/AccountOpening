using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.Ports.DrivingPorts;
using AccountOpening.Core.Domain.Entities;

namespace AccountOpening.Core.Application.UseCases
{
    internal class OpeningAccountUseCase : IOpeningAccountUseCase
    {
        public async Task OpenAccount(OpenAccountRequestDto openAccountRequest)
        {
            // Call repository to retrieve the client by ID.

            var account = new Account(new Client(), openAccountRequest.ClientId);

            // Call repository to save the account.
        }
    }
}
