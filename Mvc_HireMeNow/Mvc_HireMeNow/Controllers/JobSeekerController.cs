
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using System.Collections.Generic;

namespace Mvc_HireMeNow.Controllers
{
	public class JobSeekerController : Controller
	{
		IJobService _jobService;
		IUserService _userService;
		IUserRepository _userRepository;
		IApplicationService _applicationService;
		public JobSeekerController(IJobService jobService, IUserService userService, IUserRepository userRepository, IApplicationService applicationService)
        {
			_jobService = jobService;
			_userService = userService;
			_userRepository = userRepository;
			_applicationService = applicationService;
		}
		public List<Job> jobs { get; set; } = new List<Job>();
		public IActionResult Alljobs(Guid?selectedJobId = null)
		{

			jobs = _jobService.GetJobs();

			Job selectedJob = new Job();
			selectedJob = jobs.FirstOrDefault(new Job());
			if (selectedJobId != null)
			{
				selectedJob = _jobService.getJobById(selectedJobId.Value);

			}

			ViewBag.selectedJob = selectedJob;
			return View(jobs);
		
		}
		[HttpPost]
		public IActionResult ApplyJob(string jobId = null)
		{
			if (jobId != null)
			{
				var uid = HttpContext.Session.GetString("UserId");

				_applicationService.AddApplication(new Guid(jobId), new Guid(uid));


				return RedirectToAction("MyApplications");

			}
			return RedirectToAction("AllJobs");
			
		}
		public IActionResult Getjobs()
		{
			 jobs = _jobService.GetJobs();
			return View(jobs);
		}
		[HttpGet]
		public IActionResult MyApplications(Guid? selectedJobId = null)
		{
			var uid = HttpContext.Session.GetString("UserId");
			List<Application> jobs = _applicationService.GetAll(new Guid(uid));

			Job selectedJob = new Job();
			selectedJob = jobs.FirstOrDefault()?.Job;
			if (selectedJobId != null)
			{
				selectedJob = _jobService.getJobById(selectedJobId.Value);

			}

			ViewBag.selectedJob = selectedJob;
			return View(jobs);
		}

	}
}
