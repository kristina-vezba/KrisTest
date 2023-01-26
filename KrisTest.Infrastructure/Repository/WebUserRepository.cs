
using KrisTest.Domain.Entities;
using KrisTest.Domain.Interfaces;
using KrisTest.Infrastructure.Data;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Infrastructure.Repository
{
	public class WebUserRepository : GenericRepository<WebUser>, IWebUserRepository
	{
		public WebUserRepository(KrisTestContext context) : base (context)
		{
		}

		public WebUser GetWebUser(string username, string password)
		{
			var user = _context.WebUsers.FirstOrDefault(u => u.Name == username && u.Password == password);
		
			return user;
		}
	}
}
