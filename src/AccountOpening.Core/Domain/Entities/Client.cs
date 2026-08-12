using AccountOpening.Core.Domain.Common;

namespace AccountOpening.Core.Domain.Entities
{
    internal class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Document { get; private set; }
        public bool IsActive { get; private set; }

        private readonly IEnumerable<Account> _accounts;
        public IReadOnlyCollection<Account> Accounts => _accounts.ToList().AsReadOnly();

        private readonly IEnumerable<Address> _addresses;
        public IReadOnlyCollection<Address> Addresses => _addresses.ToList().AsReadOnly();
    }
}
