using AccountOpening.Core.Domain.Common;

namespace AccountOpening.Core.Domain.Entities;

public class Agency : Entity, IAggregateRoot
{
    public int AgencyNumber { get; private set; }
    
    private readonly IEnumerable<Client> _clients;
    public IReadOnlyCollection<Client> Clients => _clients.ToList().AsReadOnly();
    
    internal void AssociateClient(Client client)
    {
        if (Clients.Any(c => c.Id == client.Id))
        {
            throw new Exception("Client already associated with this agency");
        }
        
        _clients.Append(client);
    }
}