using AutoMapper;
using FoodDelivery.BLL.Models;
using FoodDelivery.DAL.Entities;

namespace FoodDelivery.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Маппінг з DAL до BLL
            CreateMap<Category, CategoryDto>();
            CreateMap<Dish, DishDto>();
            CreateMap<DAL.Entities.DayOfWeek, DayOfWeekDto>();
            CreateMap<Menu, MenuDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();

            // Маппінг з BLL до DAL
            CreateMap<CategoryDto, Category>();
            CreateMap<DishDto, Dish>();
            CreateMap<DayOfWeekDto, DAL.Entities.DayOfWeek>();
            CreateMap<MenuDto, Menu>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
