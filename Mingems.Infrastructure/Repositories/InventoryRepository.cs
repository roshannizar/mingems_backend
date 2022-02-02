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
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(MingemsDbContext context) : base(context) { }

        public async Task AddAsync(Inventory entity)
        {
            await context.Inventories.AddAsync(entity);
        }

        public IEnumerable<Inventory> Find(Expression<Func<Inventory, bool>> predicate)
        {
            return context.Inventories.Include(i => i.ImageLines).Include(i => i.Investment).AsNoTracking().AsQueryable().Where(predicate).ToList();
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await context.Inventories.Include(i => i.ImageLines).Include(i => i.Investment).AsNoTracking().AsNoTracking().ToListAsync();
        }

        public async Task<Inventory> GetByIdAsync(string id)
        {
            return await context.Inventories.Include(i => i.ImageLines).Include(i => i.Investment).AsNoTracking().AsQueryable().SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Remove(Inventory entity)
        {
            context.Inventories.Update(entity);
        }

        public async Task<Inventory> SingleOrDefaultAsync(Expression<Func<Inventory, bool>> predicate)
        {
            return await context.Inventories.Include(i => i.ImageLines).Include(i => i.Investment).AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(Inventory entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            foreach(var image in entity.ImageLines)
            {
                if (image.CreationDate.Date == DateTime.UtcNow.Date)
                    context.Entry(image).State = EntityState.Added;
                else
                    context.Entry(image).State = EntityState.Modified;
            }
        }
    }
}
