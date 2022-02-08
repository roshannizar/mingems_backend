using Microsoft.EntityFrameworkCore;
using Mingems.Core.Models;
using Mingems.Core.Repositories;
using Mingems.Infrastructure.Common;
using Mingems.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Repositories
{
    public class PrivateCodeRepository : BaseRepository<PrivateCode>, IPrivateCodeRepository
    {
        public PrivateCodeRepository(MingemsDbContext context) : base(context) { }

        public async Task AddAsync(PrivateCode entity)
        {
            await context.PrivateCodes.AddAsync(entity);
        }

        public IEnumerable<PrivateCode> Find(Expression<Func<PrivateCode, bool>> predicate)
        {
            return context.PrivateCodes.Where(predicate).OrderByDescending(p => p.ModificationDate).ToList();
        }

        public async Task<IEnumerable<PrivateCode>> GetAllAsync()
        {
            return await context.PrivateCodes.OrderByDescending(p => p.ModificationDate).ToListAsync();
        }

        public async Task<PrivateCode> GetByIdAsync(string id)
        {
            return await context.PrivateCodes.SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Remove(PrivateCode entity)
        {
            context.PrivateCodes.Update(entity);
        }

        public async Task<PrivateCode> SingleOrDefaultAsync(Expression<Func<PrivateCode, bool>> predicate)
        {
            return await context.PrivateCodes.SingleOrDefaultAsync(predicate);
        }

        public void Update(PrivateCode entity)
        {
            context.PrivateCodes.Update(entity);
        }
    }
}
