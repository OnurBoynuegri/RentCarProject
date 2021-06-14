﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{CarId=1,ColorId=1,BrandId=1,DailyPrice=500,Description="description",ModelYear=2013},
            new Car{CarId=2,ColorId=1,BrandId=1,DailyPrice=600,Description="description",ModelYear=2010},
            new Car{CarId=3,ColorId=2,BrandId=2,DailyPrice=700,Description="description",ModelYear=2021},
            new Car{CarId=4,ColorId=2,BrandId=2,DailyPrice=550,Description="description",ModelYear=2018},
            new Car{CarId=5,ColorId=3,BrandId=3,DailyPrice=500,Description="description",ModelYear=2014},
            new Car{CarId=6,ColorId=3,BrandId=3,DailyPrice=400,Description="description",ModelYear=2009},
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
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
