using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private DbSet<T> _entities;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<int> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.CreatedDate = DateTime.UtcNow;

            _entities.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.ModifiedDate = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
