using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Domain.Entities;
using AccountOpening.Core.Domain.Interfaces.Repositories;

namespace AccountOpening.Core.Application.UseCases
{
    public sealed class RegisteringClientUseCase(IClientRepository clientRepository) :
        UseCase<RegisterClientRequestDto, RegisterClientResponseDto>
    {
        protected override async Task<RegisterClientResponseDto> ExecuteAsync(RegisterClientRequestDto registerClientRequest)
        {
            var client = new Client(
                registerClientRequest.Name,
                registerClientRequest.DateOfBirth,
                registerClientRequest.Document);

            clientRepository.Add(client);

            return new RegisterClientResponseDto();
        }
    }
}
