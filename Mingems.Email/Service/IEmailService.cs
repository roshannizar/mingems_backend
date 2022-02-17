using Mingems.Core.Models;
using System.Threading.Tasks;

namespace Mingems.Email.Service
{
    public interface IEmailService
    {
        Task SendVerification(string email, string token);
        Task SendForgotPasswordLink(string email, string token);
        Task SendOrderInvoice(Order order);
    }
}
