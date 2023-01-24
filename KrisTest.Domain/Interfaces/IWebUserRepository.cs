using KrisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Interfaces
{
	public interface IWebUserRepository
	{
		WebUser? GetUserById(int id);
		IEnumerable<WebUser> GetAllUsers();
		void CreateUser(WebUser user);
		void UpdateUser(WebUser user);
		void DeleteUser(WebUser user);
	}
}
