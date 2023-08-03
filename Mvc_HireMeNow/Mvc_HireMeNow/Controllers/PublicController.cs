using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mvc_HireMeNow.Controllers
{
	public class PublicController : Controller
	{
		// GET: PublicController
		public ActionResult Registration()
		{
			return View();
		}

		// GET: PublicController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PublicController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PublicController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PublicController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PublicController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PublicController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PublicController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
