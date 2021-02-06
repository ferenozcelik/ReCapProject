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
            EfCarDal efCarDal = new EfCarDal();
            /*
            Car car1 = new Car
            {
                Id = 1,
                CarName = "Mazda",
                BrandId = 1,
                ColorId = 1,
                DailyPrice = 500,
                ModelYear = 2020
            };
            Car car2 = new Car
            {
                Id = 2,
                CarName = "Opel",
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 400,
                ModelYear = 2019
            };

            efCarDal.Add(car1);
            efCarDal.Add(car2);
            */
            
            // Yukardaki gibi eklenebilir ya da tables'da sağ tıkayıp view data yaparak eklenebilir.
            Console.WriteLine("Tüm arabalar:");
            foreach (var car in carManager2.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("Marka ID'ye göre sıralanmış arabalar:");
            foreach (var car in carManager2.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("Renk ID'ye göre sıralanmış arabalar:");
            foreach (var car in carManager2.GetCarsByColorId(2))
            {
                Console.WriteLine(car.CarName);
            }

            Car car3 = new Car
            {
                Id = 2,
                CarName = "O",
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 0,
                ModelYear = 2019
            };

            efCarDal.Add(car3);

        }
    }
}
