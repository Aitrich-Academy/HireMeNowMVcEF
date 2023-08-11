

using Mvc_HireMeNow.Data.Repositories;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using Mvc_HireMeNow.Repositories;

namespace Mvc_HireMeNow.Services
{
	public class ApplicationService : IApplicationService
	{
       	public IUserRepository _userRepository;
		public  IJobRepository _jobRepository;
		public IApplicationRepository _applicationRepository;
        public ApplicationService(IUserRepository userRepository, IJobRepository jobRepository, IApplicationRepository applicationRepository)
        {
			_userRepository = userRepository;
			_jobRepository = jobRepository;
			_applicationRepository = applicationRepository;

		}
        public void AddApplication(Guid jobId, Guid userId)
		{
			Job job = _jobRepository.GetJobById(jobId);
			Application application = new();
			application.JobId = jobId;
			application.UserId = userId;
			application.CompanyId = job.CompanyId;
		


			_applicationRepository.AddApplication(application);
		}

		//public IUserRepository _userRepository;
		//IApplicationRepository _applicationRepository;
		//public IJobRepository _jobRepository;
		//public ApplicationService(IUserRepository userRepository,IApplicationRepository applicationRepository, IJobRepository jobRepository)
		//      {
		//	_applicationRepository = applicationRepository;
		//	_userRepository=userRepository;
		//	_jobRepository=jobRepository;
		//      }

		//public void AddApplication(Guid jobId, Guid userId)
		//{
		//	User user=_userRepository.getById(userId);
		//	Job job= _jobRepository.GetJobById(jobId);
		//	_applicationRepository.AddApplication(user, job);

		//}

		//public List<Application> GetAll(Guid userId)
		//{
		//	return _applicationRepository.GetAll(userId);
		//}

		List<Application> IApplicationService.GetAll(Guid userId)
		{
			return _applicationRepository.GetAll(userId);
		}
	}
}
