using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork unitOfWork;
        public SupplierService(IUnitOfWork unitOfWork)
        {
           this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Supplier supplier)
        {
            await unitOfWork.SupplierRepository.AddAsync(supplier);
            await unitOfWork.CommitAsync();
        }

        public Task DeleteAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Supplier model)
        {
            throw new NotImplementedException();
        }
    }
}
