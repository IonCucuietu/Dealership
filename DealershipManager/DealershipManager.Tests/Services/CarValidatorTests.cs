using DealershipManager.Dtos;
using DealershipManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DealershipManager.Tests.Services
{
     public class CarValidatorTests
     {
          [Theory]
          [InlineData(null)]
          [InlineData("")]
          public void IsValidAddCarDto_NullOrEmptyCarBrand_ShouldReturnFalse(string brand)
          {
               //Arrange
               var dto = new AddCarDto
               {
                    Brand = brand,
                    Category = Models.Category.Crossover,
                    Model = "Model",
                    Price = 1000,
                    ProductionYear = 2020
               };

               var sut = new CarValidator();

               //Act

               var result = sut.IsValidAddCarDto(dto);

               //Assert
               Assert.False(result);
          }

          [Theory]
          [InlineData(null)]
          [InlineData("")]
          public void IsValidAddCarDto_NullOrEmptyCarModel_ShouldReturnFalse(string model)
          {
               //Arrange
               var dto = new AddCarDto
               {
                    Brand = "brand",
                    Category = Models.Category.Crossover,
                    Model = model,
                    Price = 1000,
                    ProductionYear = 2020
               };

               var sut = new CarValidator();

               //Act

               var result = sut.IsValidAddCarDto(dto);

               //Assert
               Assert.False(result);
          }

          [Fact]
          public void IsValidAddCarDto_FutureProductionYear_ShouldReturnFalse()
          {
               //Arrange
               var dto = new AddCarDto
               {
                    Brand = "Brand",
                    Category = Models.Category.Crossover,
                    Model = "Model",
                    Price = 1000,
                    ProductionYear = DateTime.UtcNow.Year + 1
               };

               var sut = new CarValidator();

               //Act

               var result = sut.IsValidAddCarDto(dto);

               //Assert
               Assert.False(result);
          }


          [Fact]
          public void IsValidAddCarDto_NegativePrice_ShouldReturnFalse()
          {
               //Arrange
               var dto = new AddCarDto
               {
                    Brand = "Brand",
                    Category = Models.Category.Crossover,
                    Model = "Model",
                    Price = -1000,
                    ProductionYear = DateTime.UtcNow.Year
               };

               var sut = new CarValidator();

               //Act

               var result = sut.IsValidAddCarDto(dto);

               //Assert
               Assert.False(result);
          }


          [Fact]
          public void IsValidAddCarDto_UnspecifiedCategory_ShouldReturnFalse()
          {
               //Arrange
               var dto = new AddCarDto
               {
                    Brand = "Brand",
                    Category = Models.Category.Unspecified,
                    Model = "Model",
                    Price = 1000,
                    ProductionYear = DateTime.UtcNow.Year
               };

               var sut = new CarValidator();

               //Act

               var result = sut.IsValidAddCarDto(dto);

               //Assert
               Assert.False(result);
          }

          [Fact]
          public void IsValidAddCarDto_ValidData_ShouldReturnTrue()
          {
               //Arrange
               var dto = new AddCarDto
               {
                    Brand = "Brand",
                    Category = Models.Category.Crossover,
                    Model = "Model",
                    Price = 1000,
                    ProductionYear = DateTime.UtcNow.Year
               };

               var sut = new CarValidator();

               //Act

               var result = sut.IsValidAddCarDto(dto);

               //Assert
               Assert.True(result);
          }
     }
}
