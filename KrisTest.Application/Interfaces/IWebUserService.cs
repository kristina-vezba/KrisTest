using KrisTest.Application.DTO;
using KrisTest.Domain.Entities;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Application.Interfaces
{
	public interface IWebUserService
	{
		WebUserDto GetUserById(int id);
		WebUserDto ValidateCredentials(string username, string password);
	}
}
