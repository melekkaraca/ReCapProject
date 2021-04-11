using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
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

        public IResult Delete(Rental entity)
        {
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

        public IResult Rent(RentDto rentDto)
        {
            IResult result = BusinessRules.Run(CheckDate(rentDto.CarId), CheckFindexPoint(rentDto.CustomerId));
            if (result != null)
            {
                return result;
            }
            
            return new SuccessResult();
        }

        private IResult CheckDate(int carId)
        {
            var carRental = GetById(carId);
            if (carRental.Data != null)
            {
                if (carRental.Data.ReturnDate == null)
                {
                    return new ErrorResult(Messages.CarNotRentDate);
                }
            }
            return new SuccessResult();
        }
        private IResult CheckFindexPoint(int customerId)
        {
            var result = _customerService.GetFindexPoint(customerId);
            if (result.Data<0 && result.Data>1900)
            {
                return new ErrorResult(Messages.FindexPointsAreNotEnough);
            }
            return new SuccessResult();
        }
    }
}
