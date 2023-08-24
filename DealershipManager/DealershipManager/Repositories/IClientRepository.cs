using DealershipManager.Models;

namespace DealershipManager.Repositories
{
     public interface IClientRepository
     {

          void Add(Client client);
          Client? Get(Guid id);
          List<Client> GetAll();
          void Update(Guid clientId, Client client);
          void Delete(Guid id);
     }
}
