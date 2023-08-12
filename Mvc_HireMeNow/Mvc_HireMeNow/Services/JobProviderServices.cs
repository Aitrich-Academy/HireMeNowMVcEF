using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using Mvc_HireMeNow.Repositories;

namespace Mvc_HireMeNow.Services
{
	public class JobProviderServices:IJobProvider

	{
        public IJobProviderRepository jobProviderRepository;

        public JobProviderServices(IJobProviderRepository _jobProviderRepository)
		{
            jobProviderRepository = _jobProviderRepository;
		}
		public List<Interview> sheduledinterviewlist()
		{
			return jobProviderRepository.SheduledInterviewList();
		}





		
    }
}
