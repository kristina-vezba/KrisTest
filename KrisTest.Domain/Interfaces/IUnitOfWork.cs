using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IWebUserRepository WebUsers { get; }
		int Complete();
	}
}
