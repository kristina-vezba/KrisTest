
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
		private readonly IWebUserService _webUserService;
		private readonly ITokenService _tokenService;

		public AuthenticationController(IWebUserService webUserService, ITokenService tokenService)
		{
			_webUserService = webUserService ?? throw new ArgumentNullException();
			_tokenService = tokenService ?? throw new ArgumentNullException();
		}

		[HttpPost]
		public IActionResult Authenticate(AuthenticationRequest authenticateRequest)
		{
			var user = _webUserService.ValidateCredentials(authenticateRequest.Username, authenticateRequest.Password);

			if (user == null)
			{
				return Unauthorized();
			}

			var token = _tokenService.CreateToken(user);

			var authenticateResponse = new AuthenticateResponse
			{
				Token = token,
				Id = user.User.Id,
				Username = user.User.Name,
				Password = user.User.Password
			};

			return Ok(authenticateResponse);
		}
	}
}

