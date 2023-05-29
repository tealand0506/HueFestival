using Microsoft.EntityFrameworkCore;
using HueFestival.Models;

namespace HueFestival.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>   where  TEntity : class
    {
        private readonly HueFestival_DbContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public RepositoryBase(HueFestival_DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
