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
    public class InventoryService : BaseService, IInventoryService
    {
        public InventoryService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext) { }

        public async Task CreateAsync(Inventory model)
        {
            await unitOfWork.InventoryRepository.AddAsync(model.Create(email, model));
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(model.PurchaseId);
            if (purchase == null)
                throw new NotFoundException("Purchase not found");
            unitOfWork.PurchaseRepository.Update(purchase.MovedStatus(email));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var inventory = await unitOfWork.InventoryRepository.GetByIdAsync(Id);
            if (inventory == null)
                throw new NotFoundException("inventory not found or already removed");
            var purchase = await unitOfWork.PurchaseRepository.GetByIdAsync(inventory.PurchaseId);
            unitOfWork.PurchaseRepository.Update(purchase.RevertMovedStatus(email));
            unitOfWork.InventoryRepository.Remove(inventory.Delete(email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await unitOfWork.InventoryRepository.GetAllAsync();
        }

        public async Task<Inventory> GetAsync(string Id)
        {
            return await unitOfWork.InventoryRepository.GetByIdAsync(Id);
        }

        public async Task<Inventory> GetInventoryByPurchaseId(string Id)
        {
            return await unitOfWork.InventoryRepository.GetInventoryByPurchaseId(Id);
        }

        public async Task<IEnumerable<Inventory>> SearchInventory(SearchFilterModel searchFilterModel)
        {
            var query = await unitOfWork.InventoryRepository.GetAllAsync();

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

        public async Task UpdateAsync(Inventory model)
        {
            var inventory = await unitOfWork.InventoryRepository.GetByIdAsync(model.Id);
            if (inventory == null)
                throw new NotFoundException("inventory not found or already removed");
            unitOfWork.InventoryRepository.Update(inventory.Update(email, model));
            await unitOfWork.CommitAsync();
        }
    }
}
