using System.Threading.Tasks;

namespace Mingems.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IInvestmentRepository InvestmentRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        IPrivateCodeRepository PrivateCodeRepository { get; }

        Task<int> CommitAsync();
    }
}
