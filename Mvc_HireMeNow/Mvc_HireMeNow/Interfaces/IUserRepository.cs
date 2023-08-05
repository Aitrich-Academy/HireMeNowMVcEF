using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IUserRepository
	{
		bool register(User user);
	}
}
