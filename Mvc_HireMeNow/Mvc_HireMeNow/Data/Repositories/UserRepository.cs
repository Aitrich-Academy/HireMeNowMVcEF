

using Mvc_HireMeNow.Enums;
using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Repositories
{
	public class UserRepository : IUserRepository
	{ 
		public bool register(User user)
		{
			user.Id = Guid.NewGuid();
			user.Role = Roles.JOBSEEKER;
			return true;
			//if (users.Find(e => e.Email == user.Email) == null)
			//{
			//	users.Add(user);
			//	return true;
			//}
			throw new UserAlreadyExistException(user.Email);
		}
	}
}
