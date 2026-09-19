using AccountOpening.Core.Domain.Common;

namespace AccountOpening.Core.Domain.Entities;

public class Agency : Entity, IAggregateRoot
{
    public int AgencyNumber { get; private set; }
    
    private IEnumerable<Client> _clients;
    public IReadOnlyCollection<Client> Clients => _clients.ToList().AsReadOnly();
    
    internal void AssociateClient(Client client)
    {
        if (_clients?.Any(c => c.Id == client.Id) == true)
        {
            throw new Exception("Client already associated with this agency");
        }
        
        if (_clients != null)
        {
            _clients.Append(client);
        }
        else
        {
            _clients = new List<Client> { client };
        }
    }
}