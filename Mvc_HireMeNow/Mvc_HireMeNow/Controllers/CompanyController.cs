using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Mvc_HireMeNow.Dtos;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Controllers
{
	public class CompanyController : Controller
	{

		private readonly ICompanyService _companyService;
		public readonly IUserRepository _userRepository;
		IMapper _mapper;
		private readonly ICompanyRepository _companyRepository;
		public CompanyController(ICompanyService companyService, IMapper mapper, ICompanyRepository companyRepository, IUserRepository userRepository)
		{
			_companyService = companyService;
			_mapper = mapper;
			_companyRepository = companyRepository;
			_userRepository = userRepository;
		}
		[HttpGet]
		public ActionResult CompanyRegistration()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CompanyRegistration(CompanyDto companyDto)
		{
			try
			{
				if (_companyRepository.IsUserExist(companyDto.Name))
				{
					return BadRequest("Company Already Exist");
				}
				else
				{
					Company company = _mapper.Map<Company>(companyDto);

					_companyService.Register(company);


					TempData["message"] = "added successfully";

					return View();

				}

			}
			catch
			{
				return View();
			}
		}
		public IActionResult Index()
		{
			return View();
		}




		public IActionResult MemberRegister()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MemberRegister(CompanyMemberDto companymemberDto)
		{
			try
			{
				User companymember = _mapper.Map<User>(companymemberDto);
				_companyService.MemberRegister(companymember);

				TempData["message"] = "added successfully";

				return RedirectToAction("MemberListing", "Company");
			}
			catch
			{
				return View();
			}
		}
		[HttpGet]
		public ActionResult ListCompanyMembers()
		{
			var CmpId = HttpContext.Session.GetString("CompanyId");
			List<User> companyMembers = _userRepository.memberListing(new Guid(CmpId));

			return View(companyMembers);
		}
		[HttpGet]
		public ActionResult RemoveCompanyMember()
		{
			return View();
		}
		[HttpPost]
		public ActionResult RemoveCompanyMember(UserDto userdto)
		{
			var userid = userdto.Id;
			_userRepository.memberDeleteById(userid,userdto.FirstName);
			return View();

		}



	}

}
