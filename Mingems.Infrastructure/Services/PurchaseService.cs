using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using Mingems.Shared.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class PurchaseService : BaseService, IPurchaseService
    {
        public PurchaseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext) {}

        public async Task CreateAsync(Purchase model)
        {
            await unitOfWork.PurchaseRepository.AddAsync(model.Create(email, model));
            var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(model.InvestorId);
            unitOfWork.InvestmentRepository.Update(investment.AddRemainingAmount(email, model.UnitPrice));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(Id);
            if (purchase == null)
                throw new NotFoundException("Purchase not found or already removed");
            unitOfWork.PurchaseRepository.Remove(purchase.Delete(email));
            var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(purchase.InvestorId);
            unitOfWork.InvestmentRepository.Update(investment.DeletedRemainingAmount(email, purchase.UnitPrice));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await unitOfWork.PurchaseRepository.GetAllAsync();
        }

        public async Task<Purchase> GetAsync(string Id)
        {
            return await unitOfWork.PurchaseRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Purchase model)
        {
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(model.Id);
            if (purchase == null)
                throw new NotFoundException("Purchase not found or already removed");
            unitOfWork.PurchaseRepository.Update(purchase.Update(email, model));
            var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(model.InvestorId);
            unitOfWork.InvestmentRepository.Update(investment.UpdateRemainingAmount(email, model.UnitPrice, purchase.UnitPrice));
            await unitOfWork.CommitAsync();
        }
    }
}
