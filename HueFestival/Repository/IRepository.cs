﻿namespace HueFestival.Repository
{
    public interface IRepository<TEntity> where  TEntity : class
    {       
        Task<List<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        
    }
}
