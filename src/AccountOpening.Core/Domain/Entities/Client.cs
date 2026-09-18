using AccountOpening.Core.Domain.Common;
using AccountOpening.Core.Domain.Enums;

namespace AccountOpening.Core.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Document { get; private set; }
        public bool IsActive { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        
        public Guid AgencyId { get; private set; }
        public Agency Agency { get; private set; }

        private readonly IEnumerable<Account> _accounts;
        public IReadOnlyCollection<Account> Accounts => _accounts.ToList().AsReadOnly();

        private readonly IEnumerable<Address> _addresses;
        public IReadOnlyCollection<Address> Addresses => _addresses.ToList().AsReadOnly();

        public Client() { }

        internal Client(string name, DateTime dateOfBirth, string document)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Document = document;
            IsActive = false;
            _accounts = new List<Account>();
            _addresses = new List<Address>();
        }
        
        internal void AssociateAddress(Address address)
        {
            if (Addresses.Any(a => a.AddressType == AddressType.Home))
            {
                throw new Exception("Client already has a home address");
            }
            
            _addresses.Append(address);
        }

        internal void AssociateAccount(Account account)
        {
            _accounts.Append(account);
        }
    }
}
