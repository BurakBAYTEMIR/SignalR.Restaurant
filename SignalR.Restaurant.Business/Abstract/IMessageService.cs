using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.Business.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        public void TChangeMessageStatusToFalse(int id);
        public void TChangeMessageStatusToTrue(int id);
    }
}
