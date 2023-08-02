using Mvc_HireMeNow.Models;
using Microsoft.EntityFrameworkCore;

namespace Mvc_HireMeNow.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<HireMeNowDbContext>(options =>
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
			);


			return services;
			 
		}
	}
}