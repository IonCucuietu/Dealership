﻿using DealershipManager.Models;

namespace DealershipManager.Repositories
{
     public class InMemoryCarRepository : ICarRepository
     {
          private static readonly List<Car> _cars = new List<Car>();
          public void Add(Car car)
          {
               _cars.Add(car);
          }

          public Car? Get(Guid id)
          {
               return _cars.FirstOrDefault(c => c.Id == id);
          }

          public List<Car> GetAll(bool isSold)
          {
               return _cars.Where(c =>  c.IsSold == isSold).ToList();
          }

          public void Update(Car car)
          {
               var carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);     

               if (carToUpdate != null)
               {
                    carToUpdate.Brand = car.Brand;
                    carToUpdate.Model = car.Model;
                    carToUpdate.Category = car.Category;
                    carToUpdate.Price = car.Price;
                    carToUpdate.ProductionYear = car.ProductionYear;
               }
          }

          public void Delete(Guid id)
          {
              var carToDelete = _cars.FirstOrDefault(c => c.Id == id);

               if (carToDelete != null)
               {
                    _cars.Remove(carToDelete);
               }
          }

        
     }
}
