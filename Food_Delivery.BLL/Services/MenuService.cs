using FoodDelivery.DAL.Entities;
using FoodDelivery.DAL.Repositories;

public class MenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly IDishRepository _dishRepository;

    public MenuService(IMenuRepository menuRepository, IDishRepository dishRepository)
    {
        _menuRepository = menuRepository;
        _dishRepository = dishRepository;
    }

    public List<Dish> GetMenuForDay(int dayOfWeekId)
    {
        return _menuRepository.GetDishesByDayOfWeek(dayOfWeekId);
    }

    public List<Dish> GetDishesByCategory(int categoryId)
    {
        return _dishRepository.GetByCategoryId(categoryId);
    }
}