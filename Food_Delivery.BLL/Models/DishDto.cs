namespace FoodDelivery.BLL.Models
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
