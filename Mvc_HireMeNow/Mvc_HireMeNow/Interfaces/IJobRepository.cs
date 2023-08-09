

using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
    public interface IJobRepository
    {
		Job GetJobById(Guid selectedJobId);
		bool Create(Job job);
		//      Job PostJob(Job job);
		//Job Update(Job job);
		List<Job> GetJobs();
		//Job GetJobById(Guid selectedJobId);
		//List<Job> GetJobsByIds(List<Guid> appliedJobsIds);
		

		//void DeleteById(Guid id);
		//List<Job> getByTitle(string title);
		//void DeleteById(Job jobToRemove);
	}
}
