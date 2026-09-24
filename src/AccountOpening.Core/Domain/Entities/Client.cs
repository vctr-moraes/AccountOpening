using AccountOpening.Core.Domain.Common;
using AccountOpening.Core.Domain.Enums;

namespace AccountOpening.Core.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Document { get; private set; }
        public bool IsActive { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        
        public Agency Agency { get; private set; }
        public Guid AgencyId { get; private set; }

        private readonly List<Account> _accounts = new();
        public IReadOnlyCollection<Account> Accounts => _accounts.AsReadOnly();

        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

        public Client() { }

        internal Client(string name, DateOnly dateOfBirth, string document, Agency agency)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Document = document;
            IsActive = false;
            Agency = agency;
            AgencyId = agency.Id;
        }
        
        internal void AssociateContacts(string phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
        
        internal void AssociateAddress(Address address)
        {
            if (Addresses.Any(a => a.AddressType == AddressType.Home))
            {
                throw new Exception("Client already has a home address");
            }
            
            _addresses.Add(address);
        }

        internal void AssociateAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}
