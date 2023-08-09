using Mvc_HireMeNow.Enums;
using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Data.Repositories
{
	public class CompanyRepository : ICompanyRepository
    {
        HireMeNowDbContext context;


        public CompanyRepository(HireMeNowDbContext _context)
        {
            context = _context;
        }
        public Company? Register(Company company)
        {
            company.Id = Guid.NewGuid();

            context.Companies.Add(company);
            context.SaveChanges();
            return company;

        }

        public bool IsUserExist(string Name)
        {
            return context.Companies.Where(e => e.Name == Name).ToList().Count > 0;
        }
        public bool registerMember(User user)
        {
            user.Id = new Guid();
            user.Role = Roles.COMPANY_MEMBER;

            if (context.Users.Where(e => user.Email == e.Email).Count() <= 0)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            throw new UserAlreadyExistException(user.Email);
        }
    }
}
