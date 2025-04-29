using FoodDelivery.DAL.Entities;
using FoodDelivery.DAL.Repositories.Interfaces;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDishRepository _dishRepository;

    public OrderService(IOrderRepository orderRepository, IDishRepository dishRepository)
    {
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
    }

    public Order CreateOrder()
    {
        var newOrder = new Order { OrderDate = DateTime.Now, OrderStatus = "Нове" };
        _orderRepository.Add(newOrder);
        _orderRepository.SaveChanges();
        return newOrder;
    }

    public void AddDishToOrder(Order order, Dish dish, int quantity)
    {
        _orderRepository.AddDishToOrder(order, dish, quantity);
    }

    public List<OrderItem> GetOrderItems(int orderId)
    {
        return _orderRepository.GetOrderItems(orderId);
    }

    public decimal CalculateTotalOrderPrice(int orderId)
    {
        return _orderRepository.CalculateTotalPrice(orderId);
    }
}
