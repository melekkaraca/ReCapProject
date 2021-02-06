using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.ModelYear + " " + item.Description);
            //}
            CarManager carManager = new CarManager(new EFCarDal());
            Car car = new Car()
            {
                CarName = "Test",
                ColorId = 1,
                BrandId = 2,
                DailyPrice = 100,
                Description = "Açıklama",
                ModelYear = 2015
            };
            carManager.Add(car);
        }
    }
}
