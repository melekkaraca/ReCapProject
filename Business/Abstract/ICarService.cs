using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IBusinessRepository<Car>
    {
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //Car GetById(int id);
        //List<Car> GetAll();
        //List<Car> GetCarsByBrandId(int id);
        //List<Car> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetail();
        IDataResult<List<CarDetailDto>> GetAllCarDetailByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetailByColorId(int id);
    }
}
