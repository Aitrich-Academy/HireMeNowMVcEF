using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Dtos;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using System.Threading.Tasks.Dataflow;

namespace Mvc_HireMeNow.Controllers
{
	public class JobProviderController : Controller
	{
		IMapper _mapper;
		IJobRepository _jobRepository;
		IUserRepository _userRepository;

		public JobProviderController(IMapper mapper, IJobRepository jobRepository,IUserRepository userRepository)
		{
			_mapper = mapper;
			_jobRepository = jobRepository;
			_userRepository = userRepository;

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


	}
}
