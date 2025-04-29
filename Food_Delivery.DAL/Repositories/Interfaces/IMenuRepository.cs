using FoodDelivery.DAL.Entities;

namespace FoodDelivery.DAL.Repositories.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        List<Dish> GetDishesByDayOfWeek(int dayOfWeekId);
    }
}
