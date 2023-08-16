using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IInterviewRepository
	{
		Interview shduleInterview(Interview interview);
		List<Interview> sheduledInterviewList(Guid cmpId);
		void removeInterview(Guid id);
		
	}
}
