using Mvc_HireMeNow.Models;

namespace Mvc_HireMeNow.Interfaces
{
    public interface ICompanyService
    {
       bool MemberRegister(User newCompanyMember);
        Company? Register(Company company);
    }
}
