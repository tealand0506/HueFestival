﻿using HueFestival.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HueFestival.Repositories.IRepositories
{
    public class Repository<TEntity>  : IRepository<TEntity> where TEntity : class
    {
        private readonly HueFestival_DbContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public Repository(HueFestival_DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()//truy xuat
        {
            return await _dbSet.ToListAsync();

        }


        public async Task PostAsync(TEntity entity)//them
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task PutAsync(TEntity entity)//sua
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(TEntity entity)//xoa
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<TEntity?> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }


        public async Task<List<TEntity>> TruyXuatTheoLoai ( params Expression<Func<TEntity, object>>[] PhanLoai)
        {
            var query = _context.Set<TEntity>().AsQueryable();//truy xuat doi tuong

            if (PhanLoai != null)//neu truy van thanh cong + Phanloai
            {
                query = PhanLoai.Aggregate(query, (current, PhanLoai) => current.Include(PhanLoai));
            }

            return await query.ToListAsync();
        }
    }
}
