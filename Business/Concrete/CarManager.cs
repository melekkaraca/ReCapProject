using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.CarName.Length > 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                }
                else
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır");
                }
            }
            else
            {
                Console.WriteLine("Araba adı minimum 2 karakter olmalıdır.");
            }
            
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public Car GetById(int id)
        {
            return _carDal.Get(c=> c.Id == id);
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }
        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}
