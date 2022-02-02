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
    public class SubscriptionRepository :BaseRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(MingemsDbContext context) : base(context) { }

        public async Task AddAsync(Subscription entity)
        {
            await context.Subscriptions.AddAsync(entity);
        }

        public IEnumerable<Subscription> Find(Expression<Func<Subscription, bool>> predicate)
        {
            return context.Subscriptions.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> GetByIdAsync(string id)
        {
            return await context.Subscriptions.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Remove(Subscription entity)
        {
            context.Subscriptions.Update(entity);
        }

        public async Task<Subscription> SingleOrDefaultAsync(Expression<Func<Subscription, bool>> predicate)
        {
            return await context.Subscriptions.SingleOrDefaultAsync(predicate);
        }

        public void Update(Subscription entity)
        {
            context.Subscriptions.Update(entity);
        }
    }
}
