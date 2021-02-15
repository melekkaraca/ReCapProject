using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IBusinessRepository<T> where T : class, IEntity, new ()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(int id);
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll();
    }
}
