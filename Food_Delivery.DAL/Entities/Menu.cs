namespace FoodDelivery.DAL.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public int DayOfWeekId { get; set; }  // Зовнішній ключ до DayOfWeek
        public DayOfWeek DayOfWeek { get; set; }  // Навігаційна властивість для зв'язку з DayOfWeek
        public List<MenuDish> MenuDishes { get; set; } = new List<MenuDish>();  // Зв'язок багато-до-багатьох з Dish через MenuDish
        public List<Dish> Dishes => MenuDishes.Select(md => md.Dish).ToList();
    }
}
