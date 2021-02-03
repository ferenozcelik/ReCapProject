using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }

        public List<Car> GetById(int id)
        {
            return _carDAL.GetById(id);
        }
    }
}
