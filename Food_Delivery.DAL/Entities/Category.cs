namespace FoodDelivery.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>();  // Навігаційна властивість для зв'язку один-до-багатьох з Dish
    }
}
