using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IJobProvider
	{
		List<Interview> sheduledinterviewlist();
		
	}
}
