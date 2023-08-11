using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using Mvc_HireMeNow.Services;

namespace Mvc_HireMeNow.Controllers
{
	public class AdminController : Controller
	{
		public readonly IAdminService _adminService;
		public readonly IJobService _JobService;
		public User loggedUser;
		string uid;
		public AdminController(IAdminService adminService, IJobService JobService)
        {
			_adminService = adminService;
			_JobService = JobService;

		}
        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(string email, string password)
		{
			try

			{
				var result = _adminService.LoginAdmin(email, password);
				if (result != null && result?.Role == Enums.Roles.Admin)
				{
					TempData["msg"] = "logged successfully";
					HttpContext.Session.SetString("UserID", result.Id.ToString());
					return RedirectToAction("joblist");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View();
				}

			}
			catch
			{
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View();
			}
		}
		public IActionResult UpdateProfile()
		{
			User user = _adminService.getLoggedUser();
			if (user.Email != null)
			{
				return View(user);
			}

				return View(loggedUser);
			}


		[HttpPost]
		public IActionResult UpdateProfile(User updatedAdmin)
		{

			uid = HttpContext.Session.GetString("UserID");
			if (uid != null)
			{
		User updatedUser = _adminService.UpdateProfile(updatedAdmin);
				TempData["messag"] = "Updated successfully";
				return View(updatedUser);
			}
			return View();
		}
		public IActionResult JobList()
		{
			List<Job> joblist = _JobService.GetJobs();
			return View("joblist", joblist);
		}
		public ActionResult JobSeekerListing()
		{
			try
			{
				List<User> jobseekers = _adminService.JobSeekerListing();

				return View(jobseekers);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
