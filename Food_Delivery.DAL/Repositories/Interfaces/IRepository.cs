namespace FoodDelivery.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        IQueryable<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
