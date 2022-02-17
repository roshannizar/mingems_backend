using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Email.Service;
using Mingems.Infrastructure.Common;
using Mingems.Queues.Services;
using Mingems.Shared.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IEmailService emailService;
        private readonly IBackgroundService backgroundService;
        private readonly INotificationService notificationService;

        public OrderService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            IEmailService emailService, IBackgroundService backgroundService, INotificationService notificationService) : 
            base(unitOfWork, httpContextAccessor)
        {
            this.emailService = emailService;
            this.backgroundService = backgroundService;
            this.notificationService = notificationService;
        }

        public async Task CreateAsync(Order model)
        {
            foreach(var item in model.OrderLines)
            {
                var product = await unitOfWork.PurchaseRepository.GetByIdAsync(item.ProductId);
                item.ActualPrice = (decimal)(product.CertificateCost + product.CommissionCost + product.ExportCost + product.RecuttingCost + product.UnitPrice);
                unitOfWork.PurchaseRepository.Update(product.UpdateQuantity(email));
            }

            await unitOfWork.OrderRepository.AddAsync(model.Create(email, model));
            await unitOfWork.CommitAsync();

            var order = await unitOfWork.OrderRepository.GetByIdAsync(model.Id);
            await emailService.SendOrderInvoice(order);

            await notificationService.SendNotification($"Order has been placed and invoice has been sent to {model.CustomerId}");
        }

        public Task DeleteAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await unitOfWork.OrderRepository.GetAllAsync();
        }

        public async Task<Order> GetAsync(string Id)
        {
            return await unitOfWork.OrderRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Order>> GetOrderByStatus(int status)
        {
            var query = await unitOfWork.OrderRepository.GetAllAsync();

            if (status == 0)
                return query.Where(o => (int)o.OrderStatus == status).ToList();
            else if (status == 1)
                return query.Where(o => (int)o.OrderStatus == status).ToList();
            else if (status == 2)
                return query.Where(o => (int)o.OrderStatus == status).ToList();
            else
                return query;
        }

        public Task UpdateAsync(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
