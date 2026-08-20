using AccountOpening.Core.Domain.Common;
using AccountOpening.Core.Domain.Enums;

namespace AccountOpening.Core.Domain.Entities
{
    internal class Account : Entity
    {
        public AccountType AccountType { get; private set; }
        public AccountStatus AccountStatus { get; private set; }
        public DateTime RequestedAt { get; private set; }
        public DateTime OpenedAt { get; private set; }
        public DateTime ClosedAt { get; private set; }
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }

        internal Account(Client client, Guid clientId)
        {
            AccountType = AccountType.Checking;
            AccountStatus = AccountStatus.OpeningRequested;
            RequestedAt = DateTime.Now;
            Client = client;
            ClientId = clientId;
        }

        internal void Open()
        {
            AccountStatus = AccountStatus.Open;
            OpenedAt = DateTime.Now;
        }
    }
}
