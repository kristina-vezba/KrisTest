using KrisTest.Application.DTO;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Application.Interfaces
{
	public interface IUserService
	{
		WebUserDto? GetUserByIdDto(int id);
		IEnumerable<WebUserDto> GetAllUsersDto();
		void CreateUserDto (WebUserDto userDto);
		void UpdateUserDto(WebUserDto userDto);
		void DeleteUserDto(WebUserDto userDto);
	}
}
