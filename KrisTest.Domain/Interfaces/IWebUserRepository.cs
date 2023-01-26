using KrisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Interfaces
{
	public interface IWebUserRepository : IGenericRepository<WebUser>
	{
		WebUser GetWebUser(string username, string password);
	}
}
