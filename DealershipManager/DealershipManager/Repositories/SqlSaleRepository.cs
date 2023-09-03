using DealershipManager.Data;
using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;

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


          public List<Sale> GetAll(DateTime startDate, DateTime endDate)
          {
               return _applicationDbContex.Sales
                   .Where(s => s.Date >= startDate & s.Date <= endDate)
                   .Include(s => s.Car)
                   .Include(s => s.Client)
                   .ToList();
          }
     }
}
