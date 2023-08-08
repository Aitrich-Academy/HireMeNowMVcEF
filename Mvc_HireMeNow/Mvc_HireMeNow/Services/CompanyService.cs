using Mvc_HireMeNow.Data.Repositories;
using Mvc_HireMeNow.Exceptions;
using Mvc_HireMeNow.Interfaces;
using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Services
{
   
    public class CompanyService : ICompanyService
    {
        public ICompanyRepository _CompanyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _CompanyRepository = companyRepository;
        }

        public Company? Register(Company company)
        {
            return _CompanyRepository.Register(company);
        }
        public bool MemberRegister(User newCompanyMember)
        {
            try
            {
                _CompanyRepository.registerMember(newCompanyMember);


                Console.WriteLine("Registration successful");
                return true;
            }
            catch (UserAlreadyExistException ex)
            {
                throw ex;
            }
            catch (Exception ex) { throw ex; }
        }

    }

}
