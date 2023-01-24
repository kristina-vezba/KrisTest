
using KrisTest.Application.DTO;
using KrisTest.Application.Interfaces;
using KrisTest.Infrastructure.Data;
using KrisTestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NodaTime;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace KrisTestAPI.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly KrisTestContext _context;

		public AuthenticationController(IConfiguration configuration, KrisTestContext context)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_context = context ?? throw new ArgumentNullException();
		}

		[HttpPost]
		public IActionResult Authenticate(AuthenticationRequest authenticateRequest)
		{
			var user = _context.WebUsers.FirstOrDefault(u => u.Name == authenticateRequest.Username && 
					u.Password == authenticateRequest.Password);

			if (user == null)
			{
				return Unauthorized();
			}

			var claimsForToken = new List<Claim>();
			claimsForToken.Add(new Claim("sub", user.Name));
			claimsForToken.Add(new Claim("name", user.Password));
			
			var token = GetToken(claimsForToken);
			var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(token);

			var authenticateResponse = new AuthenticateResponse
			{
				Token = tokenToReturn,
				Id = user.Id,
				Username = user.Name,
				Password = user.Password
			};

			return Ok(authenticateResponse);
		}

		private JwtSecurityToken GetToken(List<Claim> claimsForToken)
		{
			var securityKey = new SymmetricSecurityKey(
				Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
			var signingCredentials = new SigningCredentials(
				securityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				_configuration["Authentication:Issuer"],
				_configuration["Authentication:Audience"],
				claimsForToken,
				DateTime.UtcNow,
				DateTime.UtcNow.AddHours(1),
				signingCredentials);

			return jwtSecurityToken;
		}
	}
}

