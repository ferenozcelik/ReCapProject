using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on re.RentalCarId equals c.Id
                             join cus in context.Customers
                             on re.RentalCustomerId equals cus.CustomerId
                             join us in context.Users
                             on cus.UserId equals us.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = re.RentalId,
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 UserName = us.UserFirstName + " " + us.UserLastName,
                                 CustomerName = cus.CompanyName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();
            }
            
        }
    }
}
