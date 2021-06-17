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
            CarManager carManager=new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.CarModel);
            }
        }
    }
}
