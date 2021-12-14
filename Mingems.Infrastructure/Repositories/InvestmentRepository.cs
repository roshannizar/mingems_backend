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
    public class InvestmentRepository : BaseRepository<Investment>, IInvestmentRepository
    {
        public InvestmentRepository(MingemsDbContext context) : base(context){ }

        public async Task AddAsync(Investment entity)
        {
            await context.Investments.AddAsync(entity);
        }

        public IEnumerable<Investment> Find(Expression<Func<Investment, bool>> predicate)
        {
            return context.Investments.AsNoTracking().Where(predicate).AsQueryable().OrderByDescending(i => i.ModificationDate).ToList();
        }

        public async Task<IEnumerable<Investment>> GetAllAsync()
        {
            return await context.Investments.AsNoTracking().AsQueryable().OrderByDescending(o => o.ModificationDate).ToListAsync();
        }

        public async Task<Investment> GetByIdAsync(string id)
        {
            return await context.Investments.AsNoTracking().AsQueryable().SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Remove(Investment entity)
        {
            context.Investments.Update(entity);
        }

        public async Task<Investment> SingleOrDefaultAsync(Expression<Func<Investment, bool>> predicate)
        {
            return await context.Investments.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(Investment entity)
        {
            context.Investments.Update(entity);
        }
    }
}
