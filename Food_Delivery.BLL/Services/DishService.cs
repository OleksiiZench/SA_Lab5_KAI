using FoodDelivery.DAL.Entities;
using FoodDelivery.DAL.Repositories;

public class DishService
{
    private readonly IDishRepository _dishRepository;

    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public List<Dish> GetAllDishes()
    {
        return _dishRepository.GetAll();
    }

    public Dish GetDishById(int id)
    {
        return _dishRepository.GetById(id).SingleOrDefault();
    }

    public List<Dish> SearchDishesByName(string name)
    {
        return _dishRepository.SearchByName(name);
    }
}