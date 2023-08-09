

using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
    public interface IJobService
    {
		Job getJobById(Guid selectedJobId);

		//public void PostJob(Job job);
		public List<Job> GetJobs();
  //      public Job getJobById(Guid selectedJobId);
		//void DeleteItemById(Guid id);
	}
}
