namespace FoodDelivery.DAL.Entities
{
    public class DayOfWeek
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; } = new List<Menu>();  // Навігаційна властивість для зв'язку один-до-багатьох з Menu
    }
}