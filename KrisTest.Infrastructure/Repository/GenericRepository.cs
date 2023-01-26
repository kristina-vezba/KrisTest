using KrisTest.Domain.Common;
using KrisTest.Domain.Interfaces;
using KrisTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.TermStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Infrastructure.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		internal KrisTestContext _context;
		internal DbSet<T> _dbSet;

		public GenericRepository(KrisTestContext context) 
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
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
