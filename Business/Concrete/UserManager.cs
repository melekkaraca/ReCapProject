using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult($"{entity.FirstName} {entity.LastName} {Messages.Added}");
        }

        public IResult Delete(int id)
        {
            var entity = GetById(id).Data;
            _userDal.Delete(entity);
            return new SuccessResult($"{entity.FirstName} {entity.LastName} {Messages.Deleted}");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult($"{entity.FirstName} {entity.LastName} {Messages.Updaded}");
        }
    }
}
