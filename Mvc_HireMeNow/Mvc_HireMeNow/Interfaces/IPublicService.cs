using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
	public interface IPublicService
	{
		public User LoginJobSeeker(string email, string password);
		public User Register(User newJobSeeker);
	}
}
