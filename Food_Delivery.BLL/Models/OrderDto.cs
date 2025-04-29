namespace FoodDelivery.BLL.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public decimal TotalPrice => OrderItems.Sum(item => item.Price * item.Quantity);
    }
}
