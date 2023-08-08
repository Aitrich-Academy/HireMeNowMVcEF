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

		public User getById(Guid userId)
		{
			return userRepository.getById(userId);
		}
	}
}
