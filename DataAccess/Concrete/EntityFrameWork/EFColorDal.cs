using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFColorDal : EFEntityRepositoryBase<Color, ReCapContext>, IColorDal
    {
        
    }
}
