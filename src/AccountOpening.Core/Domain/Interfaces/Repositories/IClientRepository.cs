using AccountOpening.Core.Domain.Entities;

namespace AccountOpening.Core.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetById(Guid id);
        Task<IEnumerable<Client>> GetAll();
        void Add(Client client);
        void Update(Client client);
        void Delete(Client client);

        void AddAccount(Account account);

        void AddAddress(Address address);
    }
}
