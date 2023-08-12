using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

using Mvc_HireMeNow.Repositories;

namespace Mvc_HireMeNow.Services
{
	public class InterviewServices : IInterviewServices
	{
		public IInterviewRepository interviewRepository;

		public InterviewServices(IInterviewRepository interviewRepository)
		{
			this.interviewRepository = interviewRepository;
		}

		public void removeInterview(Guid id)
		{
			interviewRepository.removeInterview(id);
		}

		public List<Interview> sheduledInterviewList()
		{
			return interviewRepository.sheduledInterviewList();
		}

		public Interview sheduleinterview(Interview interview)
		{
			return interviewRepository.shduleInterview(interview);
		}
	
	}
}
