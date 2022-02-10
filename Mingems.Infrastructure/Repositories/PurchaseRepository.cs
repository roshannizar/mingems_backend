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
            return context.Purchases
                .AsNoTracking()
                .Include(p => p.Investment)
                .Include(p => p.Supplier)
                .AsQueryable()
                .OrderByDescending(p => p.ModificationDate)
                .Where(predicate).ToList();
        }

        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await context.Purchases
                .AsNoTracking()
                .Include(p => p.Investment)
                .Include(p => p.Supplier)
                .AsQueryable()
                .OrderByDescending(p => p.ModificationDate)
                .ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(string id)
        {
            return await context.Purchases
                .AsNoTracking()
                .Include(p => p.Investment)
                .Include(p => p.Supplier)
                .AsQueryable()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Purchase>> GetInventories()
        {
            return await context.Purchases.Include(i => i.ImageLines).Include(i => i.Investment).Include(i => i.Supplier).AsNoTracking().AsNoTracking().OrderByDescending(i => i.ModificationDate).Where(i => i.Moved == true).ToListAsync();
        }

        public async Task<Purchase> GetInventory(string id)
        {
            return await context.Purchases.Include(i => i.ImageLines).Include(i => i.Investment).Include(i => i.Supplier).AsNoTracking().AsQueryable().SingleOrDefaultAsync(i => i.Id == id && i.Moved == true);
        }

        public void Remove(Purchase entity)
        {
            context.Purchases.Update(entity);
        }

        public async Task<Purchase> SingleOrDefaultAsync(Expression<Func<Purchase, bool>> predicate)
        {
            return await context.Purchases
                .AsNoTracking()
                .Include(p => p.Investment)
                .Include(p => p.Supplier)
                .AsQueryable()
                .SingleOrDefaultAsync(predicate);
        }

        public void Update(Purchase entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            if (entity.ImageLines != null)
            {
                foreach (var image in entity.ImageLines)
                {
                    if (image.CreationDate.Date == DateTime.UtcNow.Date)
                        context.Entry(image).State = EntityState.Added;
                    else
                        context.Entry(image).State = EntityState.Modified;
                }
            }
        }
    }
}
