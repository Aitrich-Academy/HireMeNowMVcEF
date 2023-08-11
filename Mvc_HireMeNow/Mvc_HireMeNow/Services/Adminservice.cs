using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Services
{
	public class Adminservice : IAdminService
	{
		public bool _isLogged = false;
		public IUserRepository userRepository;
		public User LoggedUser = new User();
        public Adminservice(IUserRepository _userRepository)
        {
			userRepository = _userRepository;

		}
		public User getLoggedUser()
		{
			return userRepository.getLoggedUser();
		}

		public List<User> JobSeekerListing()
		{
			
				try
				{
					List<User> list = userRepository.JobSeekerListing();

					return list;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			public User LoginAdmin(string email, string password)
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

		public User UpdateProfile(User updatedAdmin)
		{
			try
			{

			return userRepository.UpdateProfile(updatedAdmin);


				
			}
			catch (UserAlreadyExistException ex)
			{
				throw ex;
			}
			catch (Exception ex) { throw ex; }
		}
	}
}
