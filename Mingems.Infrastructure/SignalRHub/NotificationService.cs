using Microsoft.AspNetCore.SignalR;
using Mingems.Core.Services;
using Mingems.Shared.Core.Helpers;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.SignalRHub
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<MessageHub> hubContext;

        public NotificationService(IHubContext<MessageHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task SendNotification(string message)
        {
            MessageHub messageHub = new MessageHub()
            {
                Message = message
            };

            return hubContext.Clients.All.SendAsync("notification", messageHub);
        }
    }
}
