using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // carManager nesnesi CarManager class'ının bir instance'ı
            // CarManager new'lediğimizde constructor çalışacak ve bir ICarDAL
            // yani Data Access Layer vermemizi isteyecek. Biz de kullandığımız Dal olan 
            // InMemoryCarDAL'ı vereceğiz.

            /*
            CarManager carManager = new CarManager(new InMemoryCarDAL());

            // carManager.GetAll(); sadece listeyi return ettiği için bir sonuca ulaşılmaz.
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Features:\n"
                    + "Car ID: " + car.Id
                    + "\nCar Name: " + car.CarName
                    + "\nCar Brand ID: " + car.BrandId
                    + "\nCar Color ID: " + car.ColorId
                    + "\nCar Model Year: " + car.ModelYear
                    + "\nCar Daily Price: " + car.DailyPrice
                    + "\n-------------------------------------"); 
            }

            Console.WriteLine("--------------GetById Kullanımı--------------");

            foreach (var car in carManager.GetById(3))
            {
                Console.WriteLine("Car Features:\n"
                    + "Car ID: " + car.Id
                    + "\nCar Name: " + car.CarName
                    + "\nCar Brand ID: " + car.BrandId
                    + "\nCar Color ID: " + car.ColorId
                    + "\nCar Model Year: " + car.ModelYear
                    + "\nCar Daily Price: " + car.DailyPrice
                    + "\n-------------------------------------");
            }
            */

            Console.WriteLine("\n--- Entity Framework ---\n");

            CarManager carManager2 = new CarManager(new EfCarDal());
           
            
            // tables'da sağ tıkayıp view data yaparak eklenebilir.
            Console.WriteLine("All cars:");
            foreach (var car in carManager2.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nCars ordered by brand ID: ");
            foreach (var car in carManager2.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nCars ordered by color ID: ");
            foreach (var car in carManager2.GetCarsByColorId(2))
            {
                Console.WriteLine(car.CarName);
            }

            ////////////////////////
            
            Console.WriteLine("\n---- GetCarDetails ----\n");

            CarManager carManager3 = new CarManager(new EfCarDal());
            foreach (var car in carManager3.GetCarDetails())
            {
                Console.WriteLine("Car ID: " + car.CarId
                    + "\nCar Name: " + car.CarName
                    + "\nBrand Name: " + car.BrandName
                    + "\nColor ID: " + car.ColorId
                    + "\nColor Name: " + car.ColorName
                    + "\nDaily Price: " + car.DailyPrice);
                Console.WriteLine("=========================");
            }
        }
    }
}
