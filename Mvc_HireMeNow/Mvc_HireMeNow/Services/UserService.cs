using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using Mvc_HireMeNow.Repositories;

namespace Mvc_HireMeNow.Services
{
	public class UserService : IUserService
	{
		public IUserRepository userRepository;
		public UserService(IUserRepository _userRepository)
		{
			userRepository = _userRepository;
		}

		public void Addabout(string? about, Guid id)
		{
			userRepository.addAbout(about,id);
		}

		public void AddExperience(Experience experience, Guid guid)
		{
			userRepository.AddExperience(experience, guid);
		}

		

		public void AddQualification(Qualification qualification, Guid guid)
		{
			userRepository.AddQualification(qualification,guid);
		}

		public void AddSkill(Skill skills, Guid guid)
		{
			userRepository.AddSkill(skills, guid);
		}

		public User getById(Guid userId)
		{
			return userRepository.getById(userId);
		}

		public User GetById(Guid guid)
		{
			return userRepository.getById(guid);
		}
	}
}
