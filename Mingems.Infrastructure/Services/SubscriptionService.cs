using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class SubscriptionService : BaseService, ISubscriptionService
    {
        public SubscriptionService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext) { }

        public async Task CreateAsync(Subscription model)
        {
            await unitOfWork.SubscriptionRepository.AddAsync(model.Create(model));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var subscription = await unitOfWork.SubscriptionRepository.GetByIdAsync(Id);
            if (subscription == null)
                throw new DllNotFoundException("Subscription not found");
            unitOfWork.SubscriptionRepository.Remove(subscription.Delete());
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await unitOfWork.SubscriptionRepository.GetAllAsync();
        }

        public async Task<Subscription> GetAsync(string Id)
        {
            return await unitOfWork.SubscriptionRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Subscription model)
        {
            var subscription = await unitOfWork.SubscriptionRepository.GetByIdAsync(model.Id);
            if (subscription == null)
                throw new DllNotFoundException("Subscription not found");
            unitOfWork.SubscriptionRepository.Update(subscription.Update(model));
            await unitOfWork.CommitAsync();
        }
    }
}
