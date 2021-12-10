using Mingems.Core.Models;

namespace Mingems.Core.Services
{
    public interface IUtilityService
    {
        string GenerateToken(User user);
        string ValidateToken(string token);
    }
}
