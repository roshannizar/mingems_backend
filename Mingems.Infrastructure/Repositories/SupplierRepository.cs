using Microsoft.EntityFrameworkCore;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Infrastructure.Common;
using Mingems.Infrastructure.DbContexts;
using Mingems.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MingemsDbContext context) : base(context) { }
        public async Task AddAsync(Supplier entity)
        {
            await context.Suppliers.AddAsync(entity);
        }

        public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await context.Suppliers
               .ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(string id)
        {
            return await context.Suppliers
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Remove(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> SingleOrDefaultAsync(Expression<Func<Supplier, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async void Update(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();
        }
    }
}
