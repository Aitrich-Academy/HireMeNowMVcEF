using Microsoft.AspNetCore.Mvc;

namespace Mvc_HireMeNow.Controllers
{
	public class JobProviderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
