using Business.Concrete;
using DataAccess.Concrete.InMemory;
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
            CarManager carManager = new CarManager(new InMemoryCarDAL());

            // carManager.GetAll(); sadece listeyi return ettiği için bir sonuca ulaşılmaz.
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Features:\n"
                    + "Car ID: " + car.Id
                    + "\nCar Description: " + car.Description
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
                    + "\nCar Description: " + car.Description
                    + "\nCar Brand ID: " + car.BrandId
                    + "\nCar Color ID: " + car.ColorId
                    + "\nCar Model Year: " + car.ModelYear
                    + "\nCar Daily Price: " + car.DailyPrice
                    + "\n-------------------------------------");
            }
            
        }
    }
}
