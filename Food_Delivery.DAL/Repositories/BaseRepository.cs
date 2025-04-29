using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> GetById(int id)
        {
            return _dbSet.Where(e => EF.Property<int>(e, "Id") == id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

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

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            return _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Dish)
                .ToList();
        }

        public decimal CalculateTotalPrice(int orderId)
        {
            return _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Sum(oi => oi.Price * oi.Quantity);
        }

        public void AddDishToOrder(Order order, Dish dish, int quantity)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                DishId = dish.Id,
                Quantity = quantity,
                Price = dish.Price
            };

            _context.OrderItems.Add(orderItem);
            SaveChanges();
        }
    }
}