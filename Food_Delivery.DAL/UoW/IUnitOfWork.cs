using FoodDelivery.DAL.Repositories.Interfaces;

namespace FoodDelivery.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDishRepository Dishes { get; }
        IMenuRepository Menus { get; }
        IOrderRepository Orders { get; }

        void Save();
    }
}
