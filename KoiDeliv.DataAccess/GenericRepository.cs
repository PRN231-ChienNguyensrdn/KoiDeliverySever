﻿using KoiDeliv.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace Repository
{

    public class GenericRepository<T>  where T : class
    {
        protected KoiDeliveryDBContext _context;
        protected DbSet<T> _dbSet;
		//public GenericRepository()
		//{
		//	_context ??= new KoiDeliveryDBContext();
		//	_dbSet = _context.Set<T>();
		//}
		public GenericRepository(KoiDeliveryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
			_dbSet = context.Set<T>();
        }

		public void PrepareCreate(T entity)
		{
			_dbSet.Add(entity);
		}

		public void PrepareUpdate(T entity)
		{
			var tracker = _context.Attach(entity);
			tracker.State = EntityState.Modified;
		}

		public void PrepareRemove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public int Save()
		{
			return _context.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public List<T> GetAll()
		{
			return _dbSet.ToList();
		}
		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}
		public void Create(T entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public async Task<int> CreateAsync(T entity)
		{
			_dbSet.Add(entity);
			return await _context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			var tracker = _context.Attach(entity);
			tracker.State = EntityState.Modified;
			_context.SaveChanges();
		}

		public async Task<int> UpdateAsync(T entity)
		{
			var tracker = _context.Attach(entity);
			tracker.State = EntityState.Modified;
			return await _context.SaveChangesAsync();
		}

		public bool Remove(T entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChanges();
			return true;
		}

		public async Task<bool> RemoveAsync(T entity)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public T GetById(string code)
		{
			return _dbSet.Find(code);
		}

		public async Task<T> GetByIdAsync(string code)
		{
			return await _dbSet.FindAsync(code);
		}

		 
	}

}
