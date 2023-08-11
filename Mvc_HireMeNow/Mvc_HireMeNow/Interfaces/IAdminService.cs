using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IAdminService
	{
		User getLoggedUser();
		List<User> JobSeekerListing();
		User LoginAdmin(string email, string password);
		User UpdateProfile(User updatedAdmin);
	}
}
