using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.Repositories.Interfaces;
using FoodDelivery.DAL.Repositories;

namespace FoodDelivery.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDishRepository _dishRepository;
        private IMenuRepository _menuRepository;
        private IOrderRepository _orderRepository;
        private bool _disposed = false;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IDishRepository Dishes => _dishRepository ??= new DishRepository(_context);

        public IMenuRepository Menus => _menuRepository ??= new MenuRepository(_context);

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
