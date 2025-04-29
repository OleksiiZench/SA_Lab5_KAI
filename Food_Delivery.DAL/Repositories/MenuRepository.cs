using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.Entities;
using FoodDelivery.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.DAL.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(AppDbContext context) : base(context) { }

        public List<Dish> GetDishesByDayOfWeek(int dayOfWeekId)
        {
            return _context.Menus
                .Where(m => m.DayOfWeekId == dayOfWeekId)
                .Include(m => m.MenuDishes)
                .ThenInclude(md => md.Dish)
                .SelectMany(m => m.MenuDishes.Select(md => md.Dish))
                .ToList();
        }
    }
}
