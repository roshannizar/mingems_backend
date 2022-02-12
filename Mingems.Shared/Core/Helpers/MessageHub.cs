using Microsoft.AspNetCore.SignalR;

namespace Mingems.Shared.Core.Helpers
{
    public class MessageHub : Hub
    {
        public string Message { get; set; }
    }
}
