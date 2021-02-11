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
            CarTest();
            //ColorTest();
            //BrandTest();
           
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            //Brand brand = new Brand
            //{ Name = "Nissan" };
            //brandManager.Add(brand);
            var updatedBrand = brandManager.GetById(4);
            updatedBrand.Data.Name = "NISSAN";
            brandManager.Update(updatedBrand.Data);
            Console.WriteLine();
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            var deletedBrand = brandManager.GetById(3);
            brandManager.Delete(deletedBrand.Data);
            Console.WriteLine();
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            //Color color = new Color
            //{
            //    Name = "Mavi"
            //};
            //colorManager.Add(color);
            //Console.WriteLine(colorManager.GetById(3).Name);
            //var updatedColor = colorManager.GetById(3);
            //updatedColor.Name = "Gri";
            //colorManager.Update(updatedColor);
            //var deletedColor = colorManager.GetById(3);
            //colorManager.Delete(deletedColor);
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void CarTest()
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.ModelYear + " " + item.Description);
            //}
            CarManager carManager = new CarManager(new EFCarDal());
            //Car car = new Car()
            //{
            //    CarName = "Test",
            //    ColorId = 1,
            //    BrandId = 2,
            //    DailyPrice = 100,
            //    Description = "Açıklama",
            //    ModelYear = 2015
            //};
            //carManager.Add(car);
            foreach (var item in carManager.GetAllCarDetail().Data)
            {
                Console.WriteLine($"Car Name: {item.CarName} - Brand Name: {item.BrandName} - Color Name: {item.ColorName} - Daily Price: {item.DailyPrice}");
            }
        }
    }
}
