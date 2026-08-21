using AccountOpening.Core.Application.DTOs.Request;

namespace AccountOpening.Core.Application.Ports.DrivingPorts
{
    internal interface IRegisteringClientUseCase
    {
        Task RegisterClient(RegisterClientRequestDto registerClientRequest);
    }
}
