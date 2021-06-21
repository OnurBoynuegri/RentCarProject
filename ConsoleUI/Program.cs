using Business.Abstract;
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
            CarManager carManager = new CarManager(new EfCarDal());
            //RentalAdd();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("{0}--{1}--{2}--{3}", rental.CarModel,rental.CompanyName,decimal.Truncate(rental.DailyPrice),rental.FirstName);
            }


            //AddCar(carManager);
            //DeleteCarById(carManager);
            //GetCarDetail(carManager);

            //CustomerList();
            //UserList();
            //ColorList();
            //BrandList();
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021, 06, 21, 12, 0, 0),
                ReturnDate = new DateTime(2021, 06, 22, 12, 0, 0)
            });
            if (result.Success == false)
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CustomerList()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserId = 1, CompanyName = "Rentcar" });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.UserId);
            }
        }

        private static void UserList()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Onur", LastName = "Boynuegri", Email = "onur@gmail.com", Password = "123456" });
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static void ColorList()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Add(new Brand { BrandName = "Mazda" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetCarDetail(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var cars in result.Data)
                {
                    Console.WriteLine("{0}--{1}--{2}--{3}", cars.CarModel, cars.DailyPrice, cars.BrandName, cars.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car { ColorId = 1, BrandId = 1, DailyPrice = 500, Description = "asdfasd", CarModel = "GT86", ModelYear = 2012 });
        }

        private static void DeleteCarById(CarManager carManager)
        {

            carManager.Delete(carManager.GetById(5).Data);
        }
    }
}
