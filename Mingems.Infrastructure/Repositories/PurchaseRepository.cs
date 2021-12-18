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
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MingemsDbContext context) : base(context) { }

        public async Task AddAsync(Purchase entity)
        {
            await context.Purchases.AddAsync(entity);
        }

        public IEnumerable<Purchase> Find(Expression<Func<Purchase, bool>> predicate)
        {
            return context.Purchases.AsNoTracking().AsQueryable().OrderByDescending(p => p.TransactionDate).Where(predicate).ToList();
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await context.Purchases.AsNoTracking().AsQueryable().OrderByDescending(p => p.TransactionDate).ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(string id)
        {
            return await context.Purchases.AsNoTracking().AsQueryable().SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Remove(Purchase entity)
        {
            context.Purchases.Update(entity);
        }

        public async Task<Purchase> SingleOrDefaultAsync(Expression<Func<Purchase, bool>> predicate)
        {
            return await context.Purchases.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(Purchase entity)
        {
            context.Purchases.Update(entity);
        }
    }
}
