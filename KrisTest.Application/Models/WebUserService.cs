using AutoMapper;
using AutoMapper.Internal.Mappers;
using KrisTest.Application.DTO;
using KrisTest.Application.Interfaces;
using KrisTest.Domain.Interfaces;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Application.Models
{
	public class WebUserService : IUserService
	{
		private readonly IWebUserRepository _webUserRepository;

		public WebUserService(IWebUserRepository webUserRepository) 
		{ 
			_webUserRepository = webUserRepository ?? throw new ArgumentNullException(nameof(webUserRepository));
		}
		public void CreateUserDto(WebUserDto userDto)
		{
			_webUserRepository.CreateUser();
		}

		public void DeleteUserDto(WebUserDto userDto)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<WebUserDto> GetAllUsersDto()
		{
			//var users = _webUserRepository.GetAllUsers();
			//var mapped = ObjectMapper.Mapper.Map<WebUserDto>(users);
			//return mapped;
			throw new NotImplementedException();
		}

		public WebUserDto? GetUserByIdDto(int id)
		{
			throw new NotImplementedException();
		}

		public void UpdateUserDto(WebUserDto userDto)
		{
			throw new NotImplementedException();
		}
	}
}
