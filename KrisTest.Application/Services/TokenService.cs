using KrisTest.Application.DTO;
using KrisTest.Application.Interfaces;
using KrisTest.Domain.Entities;
using KrisTest.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Application.Services
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string CreateToken(WebUserDto user)
		{

			var securityKey = new SymmetricSecurityKey(
				Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
			var signingCredentials = new SigningCredentials(
				securityKey, SecurityAlgorithms.HmacSha256);

			var claimsForToken = new List<Claim>();
			claimsForToken.Add(new Claim("name", user.User.Name));
			claimsForToken.Add(new Claim("pass", user.User.Password));

			var jwtSecurityToken = new JwtSecurityToken(
				_configuration["Authentication:Issuer"],
				_configuration["Authentication:Audience"],
				claimsForToken,
				DateTime.UtcNow,
				DateTime.UtcNow.AddHours(1),
				signingCredentials);

			var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

			return tokenToReturn;
		}
	}
}
