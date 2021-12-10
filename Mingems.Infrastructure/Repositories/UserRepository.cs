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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MingemsDbContext context) :base(context) { }

        public async Task AddAsync(User entity)
        {
            await context.Users.AddAsync(entity);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return context.Users.AsNoTracking().Where(predicate).AsQueryable().ToList();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.AsNoTracking().AsQueryable().ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await context.Users.AsNoTracking().AsQueryable().SingleOrDefaultAsync(u => u.Id == id);
        }

        public void Remove(User entity)
        {
            context.Users.Update(entity);
        }

        public async Task<User> SingleOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            return await context.Users.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(User entity)
        {
            context.Update(entity);
        }
    }
}
