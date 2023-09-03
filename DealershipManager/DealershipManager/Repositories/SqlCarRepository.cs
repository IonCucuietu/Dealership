using DealershipManager.Data;
using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipManager.Repositories
{
     public class SqlCarRepository : ICarRepository
     {
          private readonly ApplicationDbContext _dbContext;

          public SqlCarRepository(ApplicationDbContext dbContext)
        {
               _dbContext = dbContext;
          }
        public void Add(Car car)
          {
               _dbContext.Cars.Add(car);
               _dbContext.SaveChanges();
          }

          public void Delete(Guid id)
          {
               var carToDelete = _dbContext.Cars.FirstOrDefault(c => c.Id == id);

               if (carToDelete != null)
               {
                   var result = _dbContext.Cars.Remove(carToDelete);
                    _dbContext.SaveChanges();
               }
          }

          public List<Car> GetByFilter(string model, string brand, int productionYear)
          {
               var cars = _dbContext.Cars
                    .Where(c => c.Brand == brand)
                    .Where(c => c.Model == model)
                    .Where(c => c.ProductionYear == productionYear)
                    .OrderBy(c => c.Price)
                    .ToList();

               return cars;
          }

          public Car? Get(Guid id)
          {
               return _dbContext.Cars.FirstOrDefault(c => c.Id == id);
          }

          public List<Car> GetAll(bool isSold)
          {
               return _dbContext.Cars
                    .Where(c => c.IsSold == isSold)
                    .ToList();   
          }

          public void Update(Car car)
          {
               var carToUpdate = _dbContext.Cars.FirstOrDefault(c =>c.Id == car.Id); 

               if (carToUpdate != null)
               {
                    carToUpdate.Brand = car.Brand;
                    carToUpdate.Model = car.Model;
                    carToUpdate.Category = car.Category;
                    carToUpdate.Price = car.Price;
                    carToUpdate.ProductionYear = car.ProductionYear;

                    _dbContext.SaveChanges();
               }
          }
     }
}
