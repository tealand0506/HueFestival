﻿namespace HueFestival.Repository.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task PostAsync(TEntity entity);
        Task PutAsync(TEntity entity);  
        Task DeleteAsync(TEntity entity);
    }
}
