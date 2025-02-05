﻿using DataAccess.Abstract;
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
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1,ColorId=1,ModelYear="2001",DailyPrice=23000,Description="AudiA5"},
                new Car {Id=2,BrandId=1,ColorId=2,ModelYear="2015",DailyPrice=35000,Description="BMW"},
                new Car {Id=3,BrandId=2,ColorId=3,ModelYear="2018",DailyPrice=111000,Description="Volkswagen"},
                new Car {Id=4,BrandId=3,ColorId=4,ModelYear="2013",DailyPrice=80000,Description="Opel"}

               };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carsToDelete);
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

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.Description = car.Description;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.BrandId = car.BrandId;
        }
    }
}
