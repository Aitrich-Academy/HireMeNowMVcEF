
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Dtos;
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
		IMapper mapper;
		public JobSeekerController(IJobService jobService, IUserService userService, IUserRepository userRepository, IApplicationService applicationService, IMapper _maper)
        {
			_jobService = jobService;
			_userService = userService;
			_userRepository = userRepository;
			_applicationService = applicationService;
			mapper=_maper;
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
		public IActionResult Profile()
		{
			var uid = HttpContext.Session.GetString("UserId");
			User user = _userService.GetById(new Guid(uid));
			UserProfileDto userProfileDto = mapper.Map<UserProfileDto>(user);
			return View(userProfileDto);
		}
		[HttpPost]
		public IActionResult Profile(UserProfileDto updateUser)
		{
			var uid = HttpContext.Session.GetString("UserId");
			User user = _userService.GetById(new Guid(uid));
			user.About = updateUser.About ?? user.About;
			_userService.Addabout(user.About,user.Id);
			_userService.AddQualification(updateUser.qualification,new Guid(uid));
			_userService.AddSkill(updateUser.skill, new Guid(uid));
			_userService.AddExperience(updateUser.experience, new Guid(uid));


			return RedirectToAction("Profile");
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
