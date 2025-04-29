namespace FoodDelivery.BLL.Models
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int DayOfWeekId { get; set; }
        public DayOfWeekDto DayOfWeek { get; set; }
        public List<DishDto> Dishes { get; set; } = new List<DishDto>();
    }
}
