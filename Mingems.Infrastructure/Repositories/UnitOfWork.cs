using Mingems.Core.Repositories;
using Mingems.Infrastructure.DbContexts;
using System.Threading.Tasks;

namespace Mingems.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MingemsDbContext context;
        private IUserRepository _userRepository;

        public UnitOfWork(MingemsDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
