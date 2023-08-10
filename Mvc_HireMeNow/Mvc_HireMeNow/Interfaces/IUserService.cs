using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IUserService
	{
		void Addabout(string? about,Guid id);
		void AddExperience(Experience experience, Guid guid);
		void AddQualification(Qualification qualification, Guid guid);
		void AddSkill(Skill skills, Guid guid);
		User GetById(Guid guid);
	}
}
