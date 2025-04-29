namespace FoodDelivery.DAL.Entities
{
    public class MenuDish
    {
        public int MenuId { get; set; }  // Зовнішній ключ до Menu
        public Menu Menu { get; set; }
        public int DishId { get; set; }  // Зовнішній ключ до Dish
        public Dish Dish { get; set; }
    }
}
