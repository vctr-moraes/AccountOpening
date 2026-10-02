using AccountOpening.Core.Domain.Common;

namespace AccountOpening.Core.Domain.Entities;

public class ApplicationMetadata : Entity
{
    public short TransactionalPassword { get; private set; }
    public string DeviceName { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Client Client { get; private set; }
    public Guid ClientId { get; private set; }
}
