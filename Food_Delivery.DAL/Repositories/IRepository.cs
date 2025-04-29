using FoodDelivery.DAL.Entities;

namespace FoodDelivery.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        IQueryable<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }

    // Специфічні інтерфейси для різних сутностей
    public interface IDishRepository : IRepository<Dish>
    {
        List<Dish> SearchByName(string name);
        List<Dish> GetByCategoryId(int categoryId);
    }

    public interface IMenuRepository : IRepository<Menu>
    {
        List<Dish> GetDishesByDayOfWeek(int dayOfWeekId);
    }

    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderItem> GetOrderItems(int orderId);
        decimal CalculateTotalPrice(int orderId);
        void AddDishToOrder(Order order, Dish dish, int quantity);
    }
}