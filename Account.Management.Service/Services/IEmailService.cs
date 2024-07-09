using Account.Management.Service.Models;

namespace Account.Management.Service.Services
{
    internal interface IEmailService
    {
        void SendEmail(Message message);
    }
}
