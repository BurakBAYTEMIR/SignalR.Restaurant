﻿using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal TTotalMoneyCaseAmount();
    }
}