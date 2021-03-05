using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
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
            #region Onceki2
            //if (car.CarName.Length < 2)
            //{
            //    return new ErrorResult(Messages.NameInValid);
            //}
            //else if (car.DailyPrice <= 0)
            //{
            //    return new ErrorResult("Araba günlük fiyatı 0'dan büyük olmalıdır");
            //}
            //else

            #endregion
        }
    
        public IResult Update(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.NameInValid);
            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult("Araba günlük fiyatı 0'dan büyük olmalıdır");
            }
            else
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.Updaded);
            }
        }
        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            _carDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.Id == id));
        }
        [PerformanceAspect(2)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.BrandId == id));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        public IDataResult<List<CarDetailDto>> GetAllCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetail());
        }
    }
}
