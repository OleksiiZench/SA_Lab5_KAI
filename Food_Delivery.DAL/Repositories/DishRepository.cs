using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.Entities;
using FoodDelivery.DAL.Repositories.Interfaces;

namespace FoodDelivery.DAL.Repositories
{
    public class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        public DishRepository(AppDbContext context) : base(context) { }

        public List<Dish> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new List<Dish>();

            return _dbSet
                .AsEnumerable()
                .Where(d => d.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()))
                .ToList();
        }

        public List<Dish> GetByCategoryId(int categoryId)
        {
            return _dbSet
                .Where(d => d.CategoryId == categoryId)
                .ToList();
        }
    }
}
