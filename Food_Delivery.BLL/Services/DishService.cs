using AutoMapper;
using FoodDelivery.BLL.Models;
using FoodDelivery.DAL.UoW;

namespace FoodDelivery.BLL.Services
{
    public class DishService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DishService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<DishDto> GetAllDishes()
        {
            var dishes = _unitOfWork.Dishes.GetAll();
            return _mapper.Map<List<DishDto>>(dishes);
        }

        public DishDto GetDishById(int id)
        {
            var dish = _unitOfWork.Dishes.GetById(id).SingleOrDefault();
            return _mapper.Map<DishDto>(dish);
        }

        public List<DishDto> SearchDishesByName(string name)
        {
            var dishes = _unitOfWork.Dishes.SearchByName(name);
            return _mapper.Map<List<DishDto>>(dishes);
        }
    }
}
