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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MingemsDbContext context) : base(context) { }

        public async Task AddAsync(Order entity)
        {
            await context.Orders.AddAsync(entity);
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Purchase)
                    .ThenInclude(o => o.Investment)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Purchase)
                    .ThenInclude(o => o.Supplier)
                .AsNoTracking()
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            return await context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Purchase)
                    .ThenInclude(o => o.Investment)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Purchase)
                    .ThenInclude(o => o.Supplier)
                .AsNoTracking()
                .AsQueryable()
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public void Remove(Order entity)
        {
            context.Orders.Update(entity);
        }

        public async Task<Order> SingleOrDefaultAsync(Expression<Func<Order, bool>> predicate)
        {
            return await context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Purchase)
                    .ThenInclude(o => o.Investment)
                .Include(o => o.OrderLines)
                    .ThenInclude(o => o.Purchase)
                    .ThenInclude(o => o.Supplier)
                .AsNoTracking()
                .AsQueryable()
                .SingleOrDefaultAsync(predicate);
        }

        public void Update(Order entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            if (entity.OrderLines != null)
            {
                foreach (var item in entity.OrderLines)
                {
                    if (item.CreationDate.Date == DateTime.UtcNow.Date)
                        context.Entry(item).State = EntityState.Added;
                    else
                        context.Entry(item).State = EntityState.Modified;
                }
            }
        }
    }
}
