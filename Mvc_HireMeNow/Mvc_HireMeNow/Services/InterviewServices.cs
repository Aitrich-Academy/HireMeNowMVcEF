using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

using Mvc_HireMeNow.Repositories;

namespace Mvc_HireMeNow.Services
{
	public class InterviewServices : IInterviewServices
	{
		public IInterviewRepository _interviewRepository;

		public InterviewServices(IInterviewRepository interviewRepository)
		{
		   _interviewRepository = interviewRepository;
		}

		public void removeInterview(Guid id)
		{
			_interviewRepository.removeInterview(id);
		}

		public List<Interview> sheduledInterviewList(Guid CmpID)
		{
			return _interviewRepository.sheduledInterviewList(CmpID);
		}

		public Interview sheduleinterview(Interview interview)
		{
			return _interviewRepository.shduleInterview(interview);
		}
	
	}
}
