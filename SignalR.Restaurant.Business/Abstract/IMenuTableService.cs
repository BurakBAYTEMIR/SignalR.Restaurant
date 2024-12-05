using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        public int TMenuTableCount();
    }
}
