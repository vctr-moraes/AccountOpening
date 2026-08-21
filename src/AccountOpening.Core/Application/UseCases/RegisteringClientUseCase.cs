using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.Ports.DrivingPorts;
using AccountOpening.Core.Domain.Entities;

namespace AccountOpening.Core.Application.UseCases
{
    internal class RegisteringClientUseCase : IRegisteringClientUseCase
    {
        public async Task RegisterClient(RegisterClientRequestDto registerClientRequest)
        {
            var client = new Client(
                registerClientRequest.Name,
                registerClientRequest.DateOfBirth,
                registerClientRequest.Document);

            // Call repository to save the client.
        }
    }
}
