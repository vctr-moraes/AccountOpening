using AccountOpening.Core.Application.DTOs;

namespace AccountOpening.Core.Application.Ports.DrivingPorts
{
    public interface IUseCase<TInput, TOutput> where TInput : Dto where TOutput : Dto
    {
        Task<TOutput> TryExecuteAsync(TInput input);
    }
}
