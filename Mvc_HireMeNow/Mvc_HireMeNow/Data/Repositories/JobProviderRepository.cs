using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace HireMeNow_MVC_Application.Repositories
{
	public class JobProviderRepository:IJobProviderRepository
	{
        HireMeNowDbContext _context;
        public JobProviderRepository(HireMeNowDbContext context)
        {

           _context = context;
        }

        public List<Interview> SheduledInterviewList()
		{
			return _context.Interviews.ToList();
		}


	}
}
