﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2 || car.DailyPrice==0)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdding);
        }

        public IResult Delete(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarDeleting);
        }

        public IDataResult<List<Car>>GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.Maintenance);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListing);

        }
           
        public IDataResult<Car> GetById(int Carid)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == Carid));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdating);
        }
    }
}
