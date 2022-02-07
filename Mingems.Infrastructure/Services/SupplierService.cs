using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using Mingems.Shared.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public SupplierService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : base(unitOfWork, httpContext) { }

        public async Task CreateAsync(Supplier supplier)
        {
            await unitOfWork.SupplierRepository.AddAsync(supplier.Create(email, supplier));
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var availableSupplier = await unitOfWork.SupplierRepository.GetByIdAsync(Id);
            if (availableSupplier == null)
                throw new NotFoundException($"{Id} Supplier Not Found");
            var purchases = await unitOfWork.PurchaseRepository.GetAllAsync();
            if (purchases.Where(p => p.SupplierId == availableSupplier.Id) != null)
                throw new InvalidException($"{availableSupplier.Name} is already connected with another record, please remove the connected records!");
            unitOfWork.SupplierRepository.Remove(availableSupplier.Delete(email));
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await unitOfWork.SupplierRepository.GetAllAsync();
        }

        public async Task<Supplier> GetAsync(string Id)
        {
            return await unitOfWork.SupplierRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            var availableSupplier = await unitOfWork.SupplierRepository.GetByIdAsync(supplier.Id);
            if (availableSupplier == null)
                throw new NotFoundException($"{supplier.Id} Supplier Not Found");
            unitOfWork.SupplierRepository.Update(availableSupplier.Update(email, supplier));
            await unitOfWork.CommitAsync();
        }
    }
}
