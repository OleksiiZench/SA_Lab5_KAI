using FoodDelivery.DAL.Entities;

namespace FoodDelivery.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderItem> GetOrderItems(int orderId);
        decimal CalculateTotalPrice(int orderId);
        void AddDishToOrder(Order order, Dish dish, int quantity);
    }
}
