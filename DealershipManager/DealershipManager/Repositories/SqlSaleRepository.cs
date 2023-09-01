using DealershipManager.Data;
using DealershipManager.Models;

namespace DealershipManager.Repositories
{
     public class SqlSaleRepository : ISaleRepository
     {
          private readonly ApplicationDbContext _applicationDbContex;

          public SqlSaleRepository(ApplicationDbContext applicationDbContex)
        {
              _applicationDbContex = applicationDbContex;
          }
        public void Add(Sale sale)
          {
               _applicationDbContex.Sales.Add(sale);
               _applicationDbContex.SaveChanges();
          }

          public List<Sale> GetAll()
          {
               return _applicationDbContex.Sales.ToList();
          }
     }
}
