using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // Car
        public static string CarAdded = "Car added.";
        public static string CarDeleted = "Car deleted.";
        public static string CarUpdated = "Car updated.";
        public static string CarNameInvalid = "Car name invalid.";
        public static string CarDailyPriceInvalid = "Car daily price invalid.";
        public static string MaintenanceTime = "System under maintenance.";
        public static string CarsListed = "Cars listed.";
        public static string CarsListedByBrandId = "Cars listed by brand id.";
        public static string CarsListedByColorId = "Cars listed by color id.";
        public static string CarDetailsListed = "Cars details listed.";

        // Rental
        public static string RentalAddedError = "Rental add error.";
        public static string RentalAdded = "Rental successfull.";
        public static string RentalDeleted = "Rental deleted.";
        public static string RentalUpdated = "Rental updated.";
        public static string RentalUpdatedError = "Rental update error.";
        public static string RentalUpdatedReturnDateError = "Rental update return date error.";
        public static string RentalUpdatedReturnDate = "Rental updated return date.";

        // User
        public static string UserAdded = "User added.";
        public static string UserDeleted = "User deleted.";
        public static string UserUpdated = "User updated.";
        public static string UsersListed = "Users listed.";
        public static string UserListedById = "User listed according to the given id.";

        // Customer
        public static string CustomerAdded = "Customer added.";
        public static string CustomerDeleted = "Customer deleted.";
        public static string CustomerUpdated = "Customer updated.";
        public static string CustomersListed = "Customers listed.";
        public static string CustomerListedById = "Customer listed according to the given id.";

        // Brand
        public static string BrandAdded = "Brand added.";
        public static string BrandDeleted = "Brand deleted.";
        public static string BrandUpdated = "Brand updated.";
        public static string BrandsListed = "Brands listed.";
        public static string BrandListedByBrandId = "Brand listed according to the given id.";

        // Color
        public static string ColorAdded = "Color added.";
        public static string ColorDeleted = "Color deleted.";
        public static string ColorUpdated = "Color updated.";
        public static string ColorsListed = "Colors listed.";
        public static string ColorListedById = "Color listed according to the given id.";
    }
}
