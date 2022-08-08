using Ahmynar_Domain.Infrastructure;

namespace Ahmynar_Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
