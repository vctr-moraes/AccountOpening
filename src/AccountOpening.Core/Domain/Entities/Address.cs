using AccountOpening.Core.Domain.Common;
using AccountOpening.Core.Domain.Enums;

namespace AccountOpening.Core.Domain.Entities
{
    internal class Address : Entity
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public AddressType AddressType { get; private set; }
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
