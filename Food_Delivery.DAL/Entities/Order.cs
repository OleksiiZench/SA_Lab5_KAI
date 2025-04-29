namespace FoodDelivery.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();  // Навігаційна властивість для зв'язку один-до-багатьох з OrderItem
    }
}
