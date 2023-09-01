using DealershipManager.Data;
using DealershipManager.Models;

namespace DealershipManager.Repositories
{
     public class SqlClientRepository : IClientRepository
     {
          private readonly ApplicationDbContext _dbContext;

          public SqlClientRepository(ApplicationDbContext dbContext)
          {
               _dbContext = dbContext;
          }
          public void Add(Client client)
          {
               _dbContext.Clients.Add(client);
               _dbContext.SaveChanges();
          }

          public void Delete(Guid id)
          {
               var clientToDelete = _dbContext.Clients.FirstOrDefault(c => c.Id == id);

               if (clientToDelete != null)
               {
                    _dbContext.Clients.Remove(clientToDelete);
                    _dbContext.SaveChanges();
               }
          }

          public Client? Get(Guid id)
          {
               return _dbContext.Clients.FirstOrDefault(c => c.Id == id);
          }

          public List<Client> GetAll()
          {
               return _dbContext.Clients.ToList();
          }

          public void Update(Guid clientId, Client client)
          {
               var clientToUpdate = _dbContext.Clients.FirstOrDefault(c => c.Id == client.Id);

               if (clientToUpdate != null)
               {
                    clientToUpdate.Name = client.Name;
                    clientToUpdate.IsCompany = client.IsCompany;
;
                    _dbContext.Update(clientToUpdate);
                    _dbContext.SaveChanges();
               }
          }
     }
}
