using Ahmynar_MVC.Models;

namespace Ahmynar_MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(AccountRegisterVM registration);
        Task Logout();
    }
}
