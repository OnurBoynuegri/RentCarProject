using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{ColorId=1,BrandId=1,DailyPrice=500,Description="description"},
            new Car{ColorId=1,BrandId=1,DailyPrice=600,Description="description"},
            new Car{ColorId=2,BrandId=2,DailyPrice=700,Description="description"},
            new Car{ColorId=2,BrandId=2,DailyPrice=550,Description="description"},
            new Car{ColorId=3,BrandId=3,DailyPrice=500,Description="description"},
            new Car{ColorId=3,BrandId=3,DailyPrice=400,Description="description"},
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add(Car entity, Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
