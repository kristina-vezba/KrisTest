using KrisTest.Application.DTO;
using KrisTest.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using KrisTestAPI.Models;
using Newtonsoft.Json;

namespace KrisTest.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient client = new HttpClient();

		public HomeController()
		{
			client.DefaultRequestHeaders.Accept
				.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Accept.Clear();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			var body = JsonConvert.SerializeObject(model);
			var requestContent = new StringContent(body, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7165/api/authentication", requestContent);
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			var user = JsonConvert.DeserializeObject<UserModel>(content);

			return View(user);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		//public IActionResult Login()
		//{
		//	return View();
		//}
	}
}