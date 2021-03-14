using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car {Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 225, Description = "Açıklama 1"},
                new Car {Id = 2, BrandId = 1, ColorId = 1, ModelYear = 2021, DailyPrice = 450, Description = "Açıklama 2"},
                new Car {Id = 3, BrandId = 2, ColorId = 3, ModelYear = 2018, DailyPrice = 170, Description = "Açıklama 3"},
                new Car {Id = 4, BrandId = 3, ColorId = 2, ModelYear = 2019, DailyPrice = 169, Description = "Açıklama 4"},
                new Car {Id = 5, BrandId = 3, ColorId = 3, ModelYear = 2019, DailyPrice = 169, Description = "Açıklama 5"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetail()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
