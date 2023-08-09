using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mvc_HireMeNow.Dtos;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Controllers
{
	public class JobProviderController : Controller
	{
		IMapper _mapper;
		IJobRepository JobRepository;

		public JobProviderController(IMapper mapper, IJobRepository jobRepository)
		{
			_mapper = mapper;
			JobRepository = jobRepository;
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
			jobDto.CompanyId = new Guid("95541DEF-A31C-4BEA-9472-6B103C708487");
			var job = _mapper.Map<Job>(jobDto);
			bool result=JobRepository.Create(job);
		
			
				TempData["Message"] = "Successfully posted Job";
			return View();


		}


	}
}
