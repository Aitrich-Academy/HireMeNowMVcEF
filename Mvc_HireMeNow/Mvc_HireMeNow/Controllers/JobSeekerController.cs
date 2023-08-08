
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

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
			jobService = _jobService;
			userService = _userService;
			userRepository = _userRepository;
			applicationService = _applicationService;
		}
      
		public IActionResult Alljobs(Guid?selectedJobId = null)
		{

			List<Job> jobs = _jobService.GetJobs();

			Job selectedJob = new Job();
			selectedJob = jobs.FirstOrDefault(new Job());
			if (selectedJobId != null)
			{
				selectedJob = _jobService.getJobById(selectedJobId.Value);

			}

			ViewBag.selectedJob = selectedJob;
			return View(jobs);
		
		}
	}
}
