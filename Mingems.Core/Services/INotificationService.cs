using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface INotificationService
    {
        Task SendNotification(string message);
    }
}
