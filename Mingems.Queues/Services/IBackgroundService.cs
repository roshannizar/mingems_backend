using System;

namespace Mingems.Queues.Services
{
    public interface IBackgroundService
    {
        void ExecuteSubscription(DateTime fromDate, DateTime toDate, string Id, string name);
    }
}
