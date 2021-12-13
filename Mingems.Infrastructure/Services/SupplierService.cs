using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.Common;
using Mingems.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
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

        public Task DeleteAsync(string Id)
        {
            throw new NotImplementedException();
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
            unitOfWork.SupplierRepository.Update(supplier.Update(email, supplier));
            await unitOfWork.CommitAsync();
        }
    }
}
