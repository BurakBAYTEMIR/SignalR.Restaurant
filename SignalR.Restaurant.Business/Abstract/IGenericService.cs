namespace SignalR.Restaurant.Business.Abstract
{
    public interface IGenericService<T> where T : class, new()
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        T TGetById(int id);
        List<T> TGetListAll();
    }
}
