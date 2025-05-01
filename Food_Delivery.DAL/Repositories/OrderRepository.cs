using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.Entities;
using FoodDelivery.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            return _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Dish)
                .ToList();
        }

        public decimal CalculateTotalPrice(int orderId)
        {
            return _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Sum(oi => oi.Price * oi.Quantity);
        }

        public void AddDishToOrder(Order order, Dish dish, int quantity)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                DishId = dish.Id,
                Quantity = quantity,
                Price = dish.Price
            };

            _context.OrderItems.Add(orderItem);
        }
    }
}
