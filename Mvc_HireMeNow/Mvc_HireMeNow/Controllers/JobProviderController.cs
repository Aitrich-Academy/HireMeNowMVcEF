using AutoMapper;
using Mvc_HireMeNow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Dtos;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Mvc_HireMeNow.Services;
using System.ComponentModel.Design;

namespace Mvc_HireMeNow.Controllers
{
	public class JobProviderController : Controller
	{
		IMapper _mapper;
		IJobRepository _jobRepository;
		IUserRepository _userRepository;
		IApplicationRepository _applicationRepository;
		IInterviewServices _interviewServices;
		public JobProviderController(IMapper mapper, IJobRepository jobRepository,IUserRepository userRepository,IApplicationRepository applicationRepository,IInterviewServices interviewServices)
		{
			_mapper = mapper;
			_jobRepository = jobRepository;
			_userRepository = userRepository;
			_applicationRepository = applicationRepository;
			_interviewServices = interviewServices;
		

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
           Application Applications = _applicationRepository.GetApplication(parameter);
			//Applications.ForEach((e) =>
			//{
			//    e.Job = _jobRepository.GetJobById(e.JobId.Value);

			//});

			//var  users = _userRepository.getById(parameter);
			InterviewDto interviewDto = new();
			interviewDto.JobId = (Guid)(Applications?.Job?.Id.Value);
			
			ViewBag.jobTitle = Applications.Job.Title;
		
			ViewBag.ComapanyId = Applications.CompanyId;
			interviewDto.JobseekerId = Applications.User.Id;
			
			interviewDto.CompanyId = (Guid)Applications.CompanyId;

			return View(interviewDto);

        }
		[HttpPost]
		public IActionResult InterviewShedule(InterviewDto interviewDto,Guid CompanyId,Guid JobseekerId,Guid JobId)
		{
			interviewDto.JobId = JobId;
			interviewDto.CompanyId = CompanyId;
			interviewDto.JobseekerId = JobseekerId;
			
			var interview = _mapper.Map<Interview>(interviewDto);
            _interviewServices.sheduleinterview(interview);
			TempData["Message"] = "Success Fully Added";
			return View(interviewDto);
        }

		[HttpGet]
		public IActionResult ListJobs()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SheduledInterviewList()
		{
			var cmpId = HttpContext.Session.GetString("CompanyId");
			List<Interview> sheduledinterviews = _interviewServices.sheduledInterviewList(new Guid(cmpId));
			if(sheduledinterviews!=null)
			{
				

				return View(sheduledinterviews);
			}
			else
			{
				return BadRequest("no interviews sheduled");
			}
			
		}
		
	}
}
