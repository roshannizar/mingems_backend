using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using Mingems.Shared.Api.Models;
using Mingems.Shared.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;
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
            if (investment != null)
                unitOfWork.InvestmentRepository.Update(investment.DeletedRemainingAmount(email, purchase.UnitPrice));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteInventoryAsync(string Id)
        {
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(Id);
            if (purchase == null)
                throw new NotFoundException("Purchase not found or already removed");
            unitOfWork.PurchaseRepository.Update(purchase.RevertMovedStatus(email));
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

        public async Task<IEnumerable<Purchase>> GetInventories()
        {
            return await unitOfWork.PurchaseRepository.GetInventories();
        }

        public async Task<Purchase> GetInventory(string Id)
        {
            return await unitOfWork.PurchaseRepository.GetInventory(Id);
        }

        public async Task<IEnumerable<Purchase>> SearchInventory(SearchFilterModel searchFilterModel)
        {
            var query = await unitOfWork.PurchaseRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchFilterModel.Barcode))
                query = query.Where(i => i.Barcode.ToLower()
                .Contains(searchFilterModel.Barcode.ToLower()));
            if (!string.IsNullOrEmpty(searchFilterModel.InvestorName))
                query = query.Where(i => i.Investment.FirstName.ToLower()
                .Contains(searchFilterModel.InvestorName.ToLower()) || i.Investment.LastName.ToLower()
                .Contains(searchFilterModel.InvestorName.ToLower()));
            if (!string.IsNullOrEmpty(searchFilterModel.InvestorRefId))
                query = query.Where(i => i.Investment.RefId.ToLower()
                .Contains(searchFilterModel.InvestorRefId.ToLower()));
            if (!string.IsNullOrEmpty(searchFilterModel.Measurement))
                query = query.Where(i => i.Measurement.ToLower()
                .Contains(searchFilterModel.Measurement.ToLower()));
            if (!string.IsNullOrEmpty(searchFilterModel.Name))
                query = query.Where(i => i.Name.ToLower()
                .Contains(searchFilterModel.Name.ToLower()));
            if (!string.IsNullOrEmpty(searchFilterModel.Weight))
                query = query.Where(i => i.Weight.ToLower()
                .Contains(searchFilterModel.Weight.ToLower()));
            if (searchFilterModel.UnitPrice > 0)
                query = query.Where(i => i.UnitPrice == searchFilterModel.UnitPrice);

            return query.ToList();
        }

        public async Task UpdateAsync(Purchase model)
        {
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(model.Id);
            if (purchase == null)
                throw new NotFoundException("Purchase not found or already removed");

            if (model.PreviousInvestorId != null && model.PreviousInvestorId != model.InvestorId)
            {
                var newInvestment = await unitOfWork.InvestmentRepository.GetByIdAsync(model.InvestorId);
                unitOfWork.InvestmentRepository.Update(newInvestment.AddRemainingAmount(email, model.UnitPrice));

                var previousInvestor = await unitOfWork.InvestmentRepository.GetByIdAsync(model.PreviousInvestorId);
                if (previousInvestor != null)
                    unitOfWork.InvestmentRepository.Update(previousInvestor.DeletedRemainingAmount(email, purchase.UnitPrice));
            } else if(model.InvestorId != null)
            {
                var investment = await unitOfWork.InvestmentRepository.GetByIdAsync(model.InvestorId);
                unitOfWork.InvestmentRepository.Update(investment.UpdateRemainingAmount(email, model.UnitPrice, purchase.UnitPrice));
            }

            unitOfWork.PurchaseRepository.Update(purchase.Update(email, model));
            await unitOfWork.CommitAsync();
        }

        public async Task UpdateInventoryAsync(Purchase model)
        {
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(model.Id);
            if (purchase == null)
                throw new NotFoundException("Purchase not found or already removed");

            unitOfWork.PurchaseRepository.Update(purchase.MovedStatus(email, model));
            await unitOfWork.CommitAsync();
        }
    }
}
