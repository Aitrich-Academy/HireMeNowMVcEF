
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Data.Repositories
{
	public class JobRepository : IJobRepository
	{
		HireMeNowDbContext _context = new HireMeNowDbContext();
        public JobRepository(HireMeNowDbContext context)
        {
			_context = context;
        }
        public Job GetJobById(Guid selectedJobId)
		{
			Job jobs = _context.Jobs.Where(e => e.Id == selectedJobId).FirstOrDefault();
			return jobs;
		}
		 
		public List<Job>GetJobs()
		{
			return _context.Jobs.ToList();
		}
	}
}
