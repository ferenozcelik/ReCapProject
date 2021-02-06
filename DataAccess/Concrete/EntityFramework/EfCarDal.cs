using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDAL
    {
        public void Add(Car entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                if (entity.CarName.Length >= 2)
                {
                    if (entity.DailyPrice > 0)
                    {
                        var addedEntity = context.Entry(entity);
                        addedEntity.State = EntityState.Added;
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalı.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Araba ismi minimum 2 karakter olmalı.");
                }
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                return filter == null ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
