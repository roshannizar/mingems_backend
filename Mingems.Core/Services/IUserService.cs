using Mingems.Core.Models;
using Mingems.Shared.Core.Helpers;
using Mingems.Shared.Service;
using System.Threading.Tasks;

namespace Mingems.Core.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<string> Authenticate(string email, string password);
        Task<User> GetMetaDataAsync(string token);
        Task UpdatePasswordAsync(PasswordModel model, string token);
        Task ForgotPasswordAsync(string email);
        Task VerifyAccountAsync(string token);
        Task ResendVerificationAsync(string email);
    }
}
