using System.ComponentModel.DataAnnotations;

namespace KrisTestAPI.Models
{
	public class AuthenticationRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
