using Hangfire;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using System;

namespace Mingems.Queues.Services
{
    public class BackgroundService : IBackgroundService
    {
        private readonly INotificationService notificationService;
        private readonly IUnitOfWork unitOfWork;

        public BackgroundService(INotificationService notificationService, IUnitOfWork unitOfWork)
        {
            this.notificationService = notificationService;
            this.unitOfWork = unitOfWork;
        }

        public void ExecuteSubscription(DateTime fromDate, DateTime toDate, string Id, string name)
        {
            var timespan = (toDate - fromDate).TotalSeconds;
            var message = $"{name} - subscription has expired";

            var jobId = BackgroundJob.Schedule(() => ExecuteCall(message), TimeSpan.FromSeconds(timespan));
        }

        public void ExecuteCall(string message)
        {
            notificationService.SendNotification(message);
        }
    }
}
