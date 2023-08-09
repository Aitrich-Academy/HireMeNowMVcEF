using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;
using Mvc_HireMeNow.Repositories;

namespace Mvc_HireMeNow.Services
{
	public class PublicService : IPublicService
	{
		public IUserRepository userRepository;
		public PublicService(IUserRepository _userRepository)
		{
			userRepository = _userRepository;
		}
		public User LoggedUser = new User();
		bool _isLogged = false;
		public User LoginJobSeeker(string email, string password)
		{
			try
			{

				LoggedUser = userRepository.login(email, password);
				if (LoggedUser.Email != null)
				{

					   Console.WriteLine("Login successful!");
					_isLogged = true;
					Console.WriteLine("Welcome " + LoggedUser.FirstName);
					return LoggedUser;
				}
				else
				{
					Console.WriteLine("Login failed. Please try again.");
					return null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw new ServiceException("technical error occured");
			}
		}

		public User Register(User user)
		{
			return userRepository.register(user);
		}
	}
}
