using AccountOpening.Core.Application.DTOs;
using AccountOpening.Core.Application.Ports.DrivingPorts;

namespace AccountOpening.Core.Application.UseCases
{
    public abstract class UseCase<TInput, TOutput> : IUseCase<TInput, TOutput> where TInput : Dto where TOutput : Dto
    {
        public async Task<TOutput> TryExecuteAsync(TInput input)
        {
            // TODO: add validations for the input dto here.
            return await ExecuteAsync(input);
        }

        protected abstract Task<TOutput> ExecuteAsync(TInput input);
    }
}
