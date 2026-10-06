using AccountOpening.Core.Domain.Common;

namespace AccountOpening.Core.Domain.Entities;

public class ApplicationMetadata : Entity
{
    public short TransactionalPassword { get; private set; }
    public string DeviceName { get; private set; }
    public DateOnly CreatedAt { get; private set; }
    public Client Client { get; private set; }
    public Guid ClientId { get; private set; }

    public ApplicationMetadata() { }
    
    public ApplicationMetadata(short transactionalPassword, Client client)
    {
        TransactionalPassword = transactionalPassword;
        DeviceName = Environment.MachineName;
        CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        Client = client;
        ClientId = client.Id;
    }
}
