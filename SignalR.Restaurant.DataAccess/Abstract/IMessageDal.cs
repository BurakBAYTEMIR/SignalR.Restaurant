using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.DataAccess.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        public void ChangeMessageStatusToFalse(int id);
        public void ChangeMessageStatusToTrue(int id);
    }
}
