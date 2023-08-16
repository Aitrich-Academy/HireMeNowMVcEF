
using Microsoft.EntityFrameworkCore;
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
			Job job = _context.Jobs.Find(selectedJobId);
			return job;
		}
		 
		public List<Job>GetJobs()
		{
			return _context.Jobs.Include(e=>e.Company).ToList();
		}
		public bool  Create(Job job)
		{
			 _context.Jobs.AddAsync(job);
			_context.SaveChanges();
			return true;
		}
	}
}
