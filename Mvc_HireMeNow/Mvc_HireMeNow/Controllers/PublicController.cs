using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Controllers
{
	public class PublicController : Controller
	{
		private readonly IPublicService _publicService;
		public PublicController(IPublicService publicService)
		{
			_publicService = publicService;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Registration(User user)
		{
			try
			{
				_publicService.Register(user);

				TempData["message"] = "added successfully";

				return RedirectToAction("Login");
			}
			catch
			{
				return View();
			}
		}
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
				var result = _publicService.LoginJobSeeker(email, password);
				if (result != null)
				{
					HttpContext.Session.SetString("UserId", result.Id.ToString());

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
