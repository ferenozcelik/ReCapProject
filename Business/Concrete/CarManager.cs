using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //ICarDAL carDAL = new ICarDAL(); NEW İŞLEMİ YAPILMAZ!
        // bir iş sınıfı başka sınıfları newlemez.

        // DataAccess'e erişmemiz lazım çünkü veri lazım.
        // Ama InMemoryCarDAL yapmadık çünkü ICarDAL yaptığımız zaman, eğer DataAccess kısmında
        // değişiklikler olursa tüm değişikliklere uyum sağlayabilir ve 
        // kodda değşiklik yapmamıza gerek kalmaz.
        ICarDAL _carDAL;

        // constructor
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public void Add(Car car)
        {
            if(car.CarName.Length >= 2)
            {
                if(car.DailyPrice > 0)
                {
                    _carDAL.Add(car);
                    Console.WriteLine("Successfully added.");
                }
                else
                {
                    Console.WriteLine("Car daily price must be greater than 0.");
                }
            }
            else
            {
                Console.WriteLine("Car name must be at least 2 characters.");
            }
        }

        public void Delete(Car car)
        {
            _carDAL.Delete(car);
            Console.WriteLine("Successfully deleted.");
        }
        public void Update(Car car)
        {
            _carDAL.Update(car);
            Console.WriteLine("Successfully updated.");
        }

        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDAL.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDAL.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDAL.GetCarDetails();
        }
    }
}
