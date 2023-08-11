

using Microsoft.EntityFrameworkCore;
using Mvc_HireMeNow.Enums;
using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using System;

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
			loggedUser = _context.Users.Where(e => e.Email == email && e.password == password).FirstOrDefault();
			return loggedUser;
		}

		public User register(User user)
		{
			user.Role = Roles.JobSeeker;
			_context.Users.Add(user);
			_context.SaveChanges();
			return user;
		}

		public User getById(Guid userId)
		{
			User user = _context.Users.Where(e => e.Id == userId).Include(x => x.Skills)
				.Include(x => x.Experiences)
				.Include(x => x.Qualifications).IgnoreAutoIncludes().FirstOrDefault();
			return user;
		}



		public void AddQualification(Qualification qualification, Guid uid)
		{
			Qualification education = new Qualification();
			education.UserId = uid;
			education.Mark = qualification.Mark;
			education.Title = qualification.Title;
			education.University = qualification.University;
			education.YearOfPassout = qualification.YearOfPassout;

			_context.Qualifications.Add(education);
			_context.SaveChanges();
		}

		public void AddExperience(Experience experience, Guid guid)
		{
			experience.UserId = guid;
			_context.Experiences.Add(experience);
			_context.SaveChanges();
		}

		public void AddSkill(Skill skills, Guid guid)
		{
			skills.UserId = guid;
			_context.Skills.Add(skills);
			_context.SaveChanges();
		}



		public void addAbout(string? about, Guid id)
		{
			User userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);


			// Update the properties with new data
			userToUpdate.About = about;

			// Update other properties as needed

			// Save changes to the database
			_context.SaveChanges();

		}

		public User getLoggedUser()
		{
			return loggedUser;
		}

		public List<User> JobSeekerListing()
		{
			return _context.Users.Where(e => e.Role == Roles.JobSeeker).ToList();
		}

		public User UpdateProfile(User updatedAdmin)
		{
			var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == updatedAdmin.Id);

			if (userToUpdate != null)
			{
				userToUpdate.FirstName = updatedAdmin.FirstName ?? userToUpdate.FirstName;
				userToUpdate.LastName = updatedAdmin.LastName ?? userToUpdate.LastName;
				userToUpdate.Email = updatedAdmin.Email ?? userToUpdate.Email;
				userToUpdate.Phone = userToUpdate.Phone;
				_context.SaveChanges();
				return userToUpdate;
			}
			return userToUpdate;
		}
	}
}
