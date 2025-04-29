namespace FoodDelivery.DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }  // Зовнішній ключ до Category
        public Category Category { get; set; }  // Навігаційна властивість для зв'язку з Category
    }
}
