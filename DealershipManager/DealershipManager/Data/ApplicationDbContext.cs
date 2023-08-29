using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipManager.Data
{
     public class ApplicationDbContext : DbContext
     {
          public DbSet<Car> Cars { get; set; }
          public DbSet<Client> Clients { get; set; }
          public DbSet<Sale> Sales { get; set; }
       

          public ApplicationDbContext(DbContextOptions options) : base(options)
          {

          }
     }
     
}
