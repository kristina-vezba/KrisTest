using AutoMapper;
using AutoMapper.Internal.Mappers;
using KrisTest.Application.DTO;
using KrisTest.Application.Interfaces;
using KrisTest.Domain.Entities;
using KrisTest.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Application.Services
{
    public class WebUserService : IWebUserService
    {
        public IWebUserRepository _webUserRepository;

        public WebUserService(IWebUserRepository webUserRepository)
        {
            _webUserRepository = webUserRepository ?? throw new ArgumentNullException(nameof(webUserRepository));
        }

		public WebUserDto GetUserById(int id)
        {
			return new WebUserDto()
			{
				User = _webUserRepository.GetById(id)
			};
        }

		public WebUserDto ValidateCredentials(string username, string password)
		{
			return new WebUserDto()
			{
				User = _webUserRepository.GetWebUser(username, password)
			};	
		}
	}
}
