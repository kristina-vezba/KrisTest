
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
	public class WebUserRepository : IWebUserRepository
	{
		private readonly KrisTestContext _context;

		public WebUserRepository(KrisTestContext context)
		{
			_context = context;
		}

		public WebUser? GetUserById(int id)
		{
			return _context.WebUsers.FirstOrDefault(u => u.Id == id);
		}

		public IEnumerable<WebUser> GetAllUsers()
		{
			return _context.WebUsers.OrderBy(u => u.Name);
		}

		public void CreateUser(WebUser userDto)
		{
			_context.WebUsers.Add(userDto);
			_context.SaveChangesAsync();
		}

		public void DeleteUser(WebUser userDto)
		{
			var selectedUser = _context.WebUsers.SingleOrDefault(u => u.Id == userDto.Id);

			if (selectedUser != null) 
			{
				_context.WebUsers.Remove(selectedUser);
				_context.SaveChangesAsync();
			}
		}

		public void UpdateUser(WebUser userDto)
		{
			var selectedUser = _context.WebUsers.SingleOrDefault(u => u.Id == userDto.Id);

			if (selectedUser != null)
			{
				_context.WebUsers.Update(selectedUser);
				_context.SaveChangesAsync();
			}
		}

		public void CreateUser()
		{
			throw new NotImplementedException();
		}
	}
}
