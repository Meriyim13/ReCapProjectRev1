using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //8.gün ödev
            //if (car.Description.Length >= 2 && car.DailyPrice > 0)
            //{
            //    Console.WriteLine("Araba ismi:" + car.Description +"\n"+
            //        "Araba günlük fiyatı :" + car.DailyPrice);
            //    _carDal.Add(car);


            //}
            //else
            //{
            //    Console.WriteLine("Kayıt edilemedi.");
            //}
            //ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);

           
            return new SuccessResult(Messages.CarAdded);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //business code
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),Messages.BrandNotAdded);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (colorId>4)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorNotAdded);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),Messages.ColorAdded);
        }
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }
    }
}
