using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IUserRepository
	{
		void addAbout(string? about,Guid id);
		void AddExperience(Experience experience, Guid guid);
		void AddQualification(Qualification qualification,Guid uid);
		void AddSkill(Skill skills, Guid guid);
		User getById(Guid userId);
		User getLoggedUser();
		List<User> JobSeekerListing();
		User login(string email, string password);
		User register(User user);
		User UpdateProfile(User updatedAdmin);
		List<User> memberListing(Guid companyId);
		void memberDeleteById(Guid id,string name);
	}
}
