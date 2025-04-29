using AutoMapper;
using FoodDelivery.BLL.Models;
using FoodDelivery.DAL.UoW;

namespace FoodDelivery.BLL.Services
{
    public class MenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MenuService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<DishDto> GetMenuForDay(int dayOfWeekId)
        {
            var dishes = _unitOfWork.Menus.GetDishesByDayOfWeek(dayOfWeekId);
            return _mapper.Map<List<DishDto>>(dishes);
        }

        public List<DishDto> GetDishesByCategory(int categoryId)
        {
            var dishes = _unitOfWork.Dishes.GetByCategoryId(categoryId);
            return _mapper.Map<List<DishDto>>(dishes);
        }
    }
}
