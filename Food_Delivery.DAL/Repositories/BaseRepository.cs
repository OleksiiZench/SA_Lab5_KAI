using FoodDelivery.DAL.Data;
using FoodDelivery.DAL.Repositories.Interfaces;
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
    }
}
