using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from b in context.Brands
                             join car in context.Cars on b.BrandId equals car.BrandId
                             join r in context.Rentals on car.CarId equals r.CarId
                             join cust in context.Customers on r.CustomerId equals cust.CustomerId
                             join u in context.Users on cust.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 CarModel = car.CarModel,
                                 DailyPrice = car.DailyPrice,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CompanyName = cust.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,

                             };
                return result.ToList();

            }
        }
    }
}
