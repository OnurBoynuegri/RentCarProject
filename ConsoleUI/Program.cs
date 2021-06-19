﻿using Business.Abstract;
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
            //AddCar(carManager);
            //DeleteCarById(carManager);
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}--{1}--{2}--{3}", cars.CarModel, cars.DailyPrice,cars.BrandName,cars.ColorName);
            }
        }

        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car { ColorId = 1, BrandId = 1, DailyPrice = 500, Description = "asdfasd", CarModel = "GT86", ModelYear = 2012 });
        }

        private static void DeleteCarById(CarManager carManager)
        {
            
            carManager.Delete(carManager.GetById(5));
        }
    }
}
