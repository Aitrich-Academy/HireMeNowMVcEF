using Mvc_HireMeNow.Models;
using Microsoft.EntityFrameworkCore;
using HireMeNowWebApi.Helpers;
using Mvc_HireMeNow.Services;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Data.Repositories;

namespace Mvc_HireMeNow.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<HireMeNowDbContext>(options =>
				options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
			);

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            return services;
			 
		}
	}
}