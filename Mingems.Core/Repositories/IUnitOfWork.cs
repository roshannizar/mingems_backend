using System.Threading.Tasks;

namespace Mingems.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task<int> CommitAsync();
    }
}
