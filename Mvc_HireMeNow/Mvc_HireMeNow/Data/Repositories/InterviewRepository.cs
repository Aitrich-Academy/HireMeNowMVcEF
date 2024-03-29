﻿using Microsoft.EntityFrameworkCore;
using Mvc_HireMeNow.Enums;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using System.ComponentModel.Design;

namespace Mvc_HireMeNow.Repositories
{
	public class InterviewRepository : IInterviewRepository
	{
		private HireMeNowDbContext _context ;

		public InterviewRepository(HireMeNowDbContext context)
		{
			_context = context;
		}

		public void removeInterview(Guid id)
		{
			throw new NotImplementedException();
		}

		//List<Interview> interviews = new();
		//List<Interview> { new Interview(new Guid(), "TCS", "Developer", "10/02/2023", "Mumbai", "10.00"), new Interview(new Guid(), "Wipro", "Developer", "11/02/2023", "EKm", "12.00"), new Interview(new Guid(), "anglo", "Accountant", "24/02/2023", "Tcr", "12.00") };
		public Interview shduleInterview(Interview interview)
		{
			
			_context.Interviews.Add(interview);
			_context.SaveChanges();


			return interview;
		}

	
		public List<Interview> sheduledInterviewList(Guid CmpId)
		{
			var shedule = _context.Interviews.Where(e => e.CompanyId == CmpId).Include(e=>e.Job).ToList();
			return shedule;
		}
		//public void removeInterview(Guid id)
		//{
		//	Interview interview = interviews.FirstOrDefault(e => e.Id == id);
		//	if (interview != null)
		//	{
		//		interviews.Remove(interview);
		//	}

		//}

	}
}
