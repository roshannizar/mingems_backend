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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MingemsDbContext context) : base(context) { }

        public async Task AddAsync(Customer entity)
        {
            await context.Customers.AddAsync(entity);
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return context.Customers.AsNoTracking().AsQueryable().OrderByDescending(c => c.ModificationDate).Where(predicate).ToList();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customers.AsNoTracking().AsQueryable().OrderByDescending(c => c.ModificationDate).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await context.Customers.AsNoTracking().AsQueryable().SingleOrDefaultAsync(c => c.Id == id);
        }

        public void Remove(Customer entity)
        {
            context.Customers.Update(entity);
        }

        public async Task<Customer> SingleOrDefaultAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await context.Customers.AsNoTracking().AsQueryable().SingleOrDefaultAsync(predicate);
        }

        public void Update(Customer entity)
        {
            context.Customers.Update(entity);
        }
    }
}
