﻿using Mvc_HireMeNow.Data.Repositories;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IApplicationRepository
	{
		public List<Application> GetAll(Guid userId);
		//public void AddApplication(User user, Job job);
		//List<Application> GetAllApplication(Guid companyid);
		//Application GetAllApplicationById(Guid id);
	}
}