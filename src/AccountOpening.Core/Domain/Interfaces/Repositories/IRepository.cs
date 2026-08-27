using AccountOpening.Core.Domain.Common;

namespace AccountOpening.Core.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot { }
}
