namespace FoodDelivery.DAL.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }  // Зовнішній ключ до Order
        public Order Order { get; set; }
        public int DishId { get; set; }  // Зовнішній ключ до Dish
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }  // Ціна за одиницю на момент замовлення (може відрізнятися від поточної ціни Dish)
    }
}
