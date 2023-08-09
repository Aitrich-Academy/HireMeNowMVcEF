

using Microsoft.EntityFrameworkCore;
using Mvc_HireMeNow.Enums;
using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Repositories
{
	public class UserRepository : IUserRepository
	{
		private HireMeNowDbContext _context;
		private static User loggedUser = new User();
		public UserRepository(HireMeNowDbContext context)
        {
			_context = context;
        }

		 public User login(string email, string password)
		{
			User res = _context.Users.Where(e => e.Email == email && e.password == password).FirstOrDefault();
			return res;
		}

	   	public User	 register(User user)
		{
			user.Role = Roles.JobSeeker; 
			_context.Users.Add(user);
			_context.SaveChanges();
			return user;
		}

		 public User getById(Guid userId)
		{
			User user = _context.Users.Where(e => e.Id == userId).FirstOrDefault();
			 return user;
		}
	}
}
