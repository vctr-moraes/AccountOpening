using AccountOpening.Core.Application.DTOs.Request;

namespace AccountOpening.Core.Application.Ports.DrivingPorts
{
    internal interface IOpeningAccountUseCase
    {
        Task OpenAccount(OpenAccountRequestDto openAccountRequest);
    }
}
