using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IUserRepository
	{
		User getById(Guid userId);
		User login(string email, string password);
		User register(User user);
	}
}
