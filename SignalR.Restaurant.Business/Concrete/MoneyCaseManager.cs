﻿using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.DataAccess.Abstract;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(MoneyCase entity)
        {
            _moneyCaseDal.Add(entity);
        }

        public void TDelete(MoneyCase entity)
        {
            _moneyCaseDal.Delete(entity);
        }

        public MoneyCase TGetById(int id)
        {
            return _moneyCaseDal.GetById(id);
        }

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);
        }
    }
}