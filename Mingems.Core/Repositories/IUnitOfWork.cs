using System.Threading.Tasks;

namespace Mingems.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IInvestmentRepository InvestmentRepository { get; }

        Task<int> CommitAsync();
    }
}
