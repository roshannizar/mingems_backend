using Microsoft.EntityFrameworkCore;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Infrastructure.Common;
using Mingems.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return context.Suppliers.AsNoTracking().Where(predicate).AsQueryable().ToList();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await context.Suppliers.AsNoTracking().AsQueryable()
               .ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(string id)
        {
            return await context.Suppliers.AsNoTracking().AsQueryable()
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Remove(Supplier entity)
        {
            context.Suppliers.Update(entity);
        }

        public async Task<Supplier> SingleOrDefaultAsync(Expression<Func<Supplier, bool>> predicate)
        {
            return await context.Suppliers.AsNoTracking().AsQueryable()
                .SingleOrDefaultAsync(predicate);
        }

        public void Update(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
        }
    }
}
