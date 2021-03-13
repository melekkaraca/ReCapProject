using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            var listCarRental = _rentalDal.GetAll(r => r.CarId == entity.CarId && r.ReturnDate == null);
            if (listCarRental.Count > 0)
            {
                return new ErrorResult(Messages.Untenantable);
            }
            _rentalDal.Add(entity);
            return new SuccessResult($" {Messages.Rental}");
        }

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            _rentalDal.Delete(entity);
            return new SuccessResult($"{Messages.Deleted}");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult($"{Messages.Updaded}");
        }
        public IDataResult<List<RentalDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetAllRentalDetail());
        }
    }
}
