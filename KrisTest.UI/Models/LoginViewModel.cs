using System.ComponentModel.DataAnnotations;

namespace KrisTest.UI.Models
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
	}
}
