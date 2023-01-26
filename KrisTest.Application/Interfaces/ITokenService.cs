using KrisTest.Application.DTO;
using KrisTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Application.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(WebUserDto user);
	}
}
