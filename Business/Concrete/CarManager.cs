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
        private List<string> Control(Car car)
        {
            List<string> cevaplar = new List<string>();
            if (car.CarName.Length < 2)
            {
                cevaplar.Add("Araba adı minimum 2 karakter olmalıdır.");
            }
            if (car.DailyPrice <= 0)
            {
                cevaplar.Add("Araba günlük fiyatı 0'dan büyük olmalıdır");
            }
            return cevaplar;
        }
        public void Add(Car car)
        {
            var cvpControl = Control(car);
            if (cvpControl.Count > 0)
            {
                foreach (var cvp in cvpControl)
                {
                    Console.WriteLine(cvp);
                }
            }
            else
            {
                _carDal.Add(car);
            }
            #region Onceki
            //if (car.CarName.Length > 2)
            //{
            //    if (car.DailyPrice > 0)
            //    {

            //    }
            //    else
            //    {
            //        Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Araba adı minimum 2 karakter olmalıdır.");
            //} 
            #endregion

        }
        public void Update(Car car)
        {
            var cvpControl = Control(car);
            if (cvpControl.Count > 0)
            {
                foreach (var cvp in cvpControl)
                {
                    Console.WriteLine(cvp);
                }
            }
            else
            {
                _carDal.Update(car);
            }
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
