using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{

	public interface IJobProviderRepository
	{
		
		List<Interview> SheduledInterviewList();
	}
}
