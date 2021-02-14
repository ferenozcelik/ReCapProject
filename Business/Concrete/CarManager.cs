using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if(car.CarName.Length >= 2)
            {
                if(car.DailyPrice > 0)
                {
                    _carDAL.Add(car);
                    //Console.WriteLine("Successfully added.");
                    return new SuccessResult(Messages.CarAdded);
                }
                else
                {
                    //Console.WriteLine("Car daily price must be greater than 0.");
                    return new ErrorResult(Messages.CarDailyPriceInvalid);
                }
            }
            else
            {
                //Console.WriteLine("Car name must be at least 2 characters.");
                return new ErrorResult(Messages.CarNameInvalid);
            }

        }

        public IResult Delete(Car car)
        {
            _carDAL.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.BrandId == brandId), Messages.CarsListedByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.ColorId == colorId), Messages.CarsListedByColorId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDAL.Get(c => c.Id == id));
        }
    }
}
