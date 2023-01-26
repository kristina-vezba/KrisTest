using KrisTest.Domain.Entities;
using KrisTest.Domain.Interfaces;
using KrisTest.Infrastructure.Data;
using KrisTest.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private KrisTestContext _context;

		public UnitOfWork(KrisTestContext context)
		{
			_context = context;
			WebUsers = new WebUserRepository(_context);
		}

		public IWebUserRepository WebUsers { get; private set; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}


		//private KrisTestContext _context = new KrisTestContext();
		//private IWebUserRepository _webUser;

		//public IWebUserRepository WebUsers
		//{
		//	get
		//	{
		//		if (_webUser == null)
		//		{
		//			_webUser = new WebUserRepository(_context);
		//		}

		//		return _webUser;
		//	}
		//}

		//public int Complete()
		//{
		//	return _context.SaveChanges();
		//}

		//private bool disposed = false;

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (!this.disposed)
		//	{
		//		if (disposing)
		//		{
		//			_context.Dispose();
		//		}
		//	}
		//	this.disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}
	}
}
