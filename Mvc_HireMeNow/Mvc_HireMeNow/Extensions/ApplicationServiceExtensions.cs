using Mvc_HireMeNow.Models;
using Microsoft.EntityFrameworkCore;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Repositories;
using Mvc_HireMeNow.Services;
using HireMeNowWebApi.Helpers;
using Mvc_HireMeNow.Data.Repositories;

namespace Mvc_HireMeNow.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContextPool<HireMeNowDbContext>(options =>
			options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
		);
			
			services.AddScoped<IPublicService, PublicService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IAdminService, Adminservice>();
			
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IJobService, JobService>();
			services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IApplicationService, ApplicationService>() ;
			services.AddScoped<IApplicationRepository, ApplicationRepository>();

			return services;
			 
		}
	}
}