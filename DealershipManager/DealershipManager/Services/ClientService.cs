using DealershipManager.Models;
using DealershipManager.Repositories;

namespace DealershipManager.Services
{
     public class ClientService : IClientService
     {
          private readonly IClientRepository _clientRepository;

          public ClientService(IClientRepository clientRepository)
          {
               _clientRepository = clientRepository;
          }
          public void Add(Client client)
          {
               _clientRepository.Add(client);
          }

          public void Delete(Guid id)
          {
               _clientRepository.Delete(id);
          }

          public Client? Get(Guid id)
          {
               return _clientRepository.Get(id);
          }

          public List<Client> GetAll()
          {
               return _clientRepository.GetAll();
          }

          public void Update(Guid clientId, Client client)
          {
               _clientRepository.Update(clientId, client);
          }
     }
}
