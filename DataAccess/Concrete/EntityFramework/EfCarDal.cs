using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarDBContext context = new RentCarDBContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars on b.BrandId equals c.BrandId
                             join color in context.Colors on c.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarModel = c.CarModel,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();

            }
        }
    }


}
