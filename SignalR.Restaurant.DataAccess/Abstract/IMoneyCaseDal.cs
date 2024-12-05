using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IMoneyCaseDal : IGenericDal<MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
    }
}
