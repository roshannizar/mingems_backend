using Mingems.Core.Repositories;
using Mingems.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MingemsDbContext context;
        private IUserRepository _userRepository;
        private ISupplierRepository _supplierRepository;
        private IInvestmentRepository _investmentRepository;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(MingemsDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);
        public ISupplierRepository SupplierRepository => _supplierRepository ??= new SupplierRepository(context);
        public IInvestmentRepository InvestmentRepository => _investmentRepository ??= new InvestmentRepository(context);
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
