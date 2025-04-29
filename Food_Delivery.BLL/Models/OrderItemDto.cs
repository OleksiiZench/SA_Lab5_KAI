namespace FoodDelivery.BLL.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public DishDto Dish { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
