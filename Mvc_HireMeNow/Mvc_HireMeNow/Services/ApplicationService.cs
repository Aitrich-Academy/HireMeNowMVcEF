

using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Services
{
	public class ApplicationService : IApplicationService
	{
		public void AddApplication(Guid userId, Guid jobId)
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}
	}
}
