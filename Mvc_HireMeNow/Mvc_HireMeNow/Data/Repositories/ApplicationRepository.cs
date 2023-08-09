using Microsoft.EntityFrameworkCore;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Repositories
{
	public class ApplicationRepository : IApplicationRepository
	{
		HireMeNowDbContext _context = new HireMeNowDbContext();
        public ApplicationRepository(HireMeNowDbContext context)
        {
            _context = context;
        }
        List<Application> _applications=new List<Application>();
		public List<Application> GetAll(Guid userId)
		{
			return _applications.Where(e=>e.User?.Id==userId).ToList();
		}
		public void AddApplication(User user, Job job)
		{
			Application app = new Application();
			//app.User= user;
			//app.Job = job;
			app.UserId = user.Id;
			app.JobId = job.Id;
			app.CompanyId = job.CompanyId;
			app.Status = "Pending";
			app.AppliedDate = DateTime.Now;
			_context.Applications.Add(app);
			_context.SaveChanges();
		}

		public void AddApplication(Application application)
		{
			_context.Applications.Add(application);
			_context.SaveChanges();
		}
	}
}
