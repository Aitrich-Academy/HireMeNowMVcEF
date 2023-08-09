using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
    public interface ICompanyRepository
    {
        Company? Register(Company company);
        bool IsUserExist(string Name);
        public bool registerMember(User newCompanyMember);

    }
}
