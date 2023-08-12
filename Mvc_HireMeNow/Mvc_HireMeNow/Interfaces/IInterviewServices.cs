using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IInterviewServices
	{
		Interview sheduleinterview(Interview interview);
		List<Interview> sheduledInterviewList();
		void removeInterview(Guid id);

	}
}
