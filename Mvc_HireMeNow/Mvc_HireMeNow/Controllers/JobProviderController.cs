using AutoMapper;
using Mvc_HireMeNow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Dtos;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace Mvc_HireMeNow.Controllers
{
	public class JobProviderController : Controller
	{
		IMapper _mapper;
		IJobRepository _jobRepository;
		IUserRepository _userRepository;
		IApplicationRepository _applicationRepository;
		public JobProviderController(IMapper mapper, IJobRepository jobRepository,IUserRepository userRepository,IApplicationRepository applicationRepository)
		{
			_mapper = mapper;
			_jobRepository = jobRepository;
			_userRepository = userRepository;
			_applicationRepository = applicationRepository;
		

		}

		public IActionResult Index()
		{
			return View();
		}
		public ActionResult PostJob()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult PostJob(JobDto jobDto)
		{
			var uid = HttpContext.Session.GetString("UserId");


			
			User user = _userRepository.getById(new Guid(uid));
			jobDto.CompanyId = (Guid)user.CompanyId;
			var job = _mapper.Map<Job>(jobDto);
			bool result=_jobRepository.Create(job);
		
			
				TempData["Message"] = "Successfully posted Job";
			return View();


		}
		[HttpGet]
		public IActionResult ListApplication()
		{
			var uid = HttpContext.Session.GetString("UserId");
			var user = _userRepository.getById(new Guid(uid));
			TempData["CompanyID"] = user.CompanyId;
			var cmpid = user.CompanyId;
			List<Application> applications = _applicationRepository.GetAllApplication((Guid)cmpid);


			


			
			return View(applications);


		}
		[HttpGet]
		public IActionResult InterviewShedule(Guid parameter)
        {
			var Apps= _applicationRepository.GetApplication(parameter);

			return View(Apps);


            
		}
		[HttpPost]
		public IActionResult InterviewShedule(InterviewDto interviewDto)
		{


			return View();
		}

		[HttpGet]
		public IActionResult ListJobs()
		{
			return View();
		}

	}
}
