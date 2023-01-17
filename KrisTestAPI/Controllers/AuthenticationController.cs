using KrisTest.Domain.Entities;
using KrisTest.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NodaTime;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static KrisTestAPI.Controllers.AuthenticationController;

namespace KrisTestAPI.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly KrisTestContext _context;

		public class AuthenticationRequestBody
		{
			public string? UserName { get; set; }
			public string? Password { get; set; }
		}

		public AuthenticationController(IConfiguration configuration, KrisTestContext context)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		[HttpPost("authenticate")]
		public ActionResult<string> Authenticate(AuthenticationRequestBody authenticateRequestBody)
		{
			var user = ValidateUserCredentials(
				authenticateRequestBody.UserName,
				authenticateRequestBody.Password);

			if (user == null)
			{
				return Unauthorized();
			}

			var securityKey = new SymmetricSecurityKey(
				Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
			var signingCredentials = new SigningCredentials(
				securityKey, SecurityAlgorithms.HmacSha256);

			var claimsForToken = new List<Claim>();
			claimsForToken.Add(new Claim("sub", user.Id.ToString()));
			claimsForToken.Add(new Claim("name", user.Name));

			var jwtSecurityToken = new JwtSecurityToken(
				_configuration["Authentication:Issuer"],
				_configuration["Authentication:Audience"],
				claimsForToken,
				DateTime.UtcNow,
				DateTime.UtcNow.AddHours(1),
				signingCredentials);

			var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

			return Ok(tokenToReturn);
		}

		private WebUser ValidateUserCredentials(string? userName, string? password)
		{
			return new WebUser();
		}
	}
}

