using FoodDelivery.DAL.Entities;

namespace FoodDelivery.DAL.Repositories.Interfaces
{
    public interface IDishRepository : IRepository<Dish>
    {
        List<Dish> SearchByName(string name);
        List<Dish> GetByCategoryId(int categoryId);
    }
}
