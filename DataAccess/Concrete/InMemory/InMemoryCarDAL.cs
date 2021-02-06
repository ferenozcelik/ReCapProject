using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDAL : ICarDAL
    {

        List<Car> _cars;

        public InMemoryCarDAL()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=500, CarName="Mazda Model 1"},
                new Car{Id=2, BrandId=2, ColorId=1, ModelYear=2019, DailyPrice=400, CarName="Ford Model 1"},
                new Car{Id=3, BrandId=3, ColorId=2, ModelYear=2017, DailyPrice=550, CarName="Chevrolet Model 1"},
                new Car{Id=4, BrandId=1, ColorId=3, ModelYear=2020, DailyPrice=700, CarName="Mazda Model 2"},
                new Car{Id=5, BrandId=4, ColorId=4, ModelYear=2015, DailyPrice=250, CarName="Opel Model 1"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarName = car.CarName;

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            // _cars listesindeki her elemana takma ad olarak "c" verdim. Listedeki her "c"nin Id'sine
            // bakacak ve parametre olarak verdiğim Id ile eşitse onları liste formatında return edecek.
            return _cars.Where(c => c.Id == id).ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
