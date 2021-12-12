using Mingems.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Mingems.Core.Models;

namespace Mingems.Infrastructure.Common
{
    public class BaseService
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IHttpContextAccessor httpContext;
        public string email { get; set; }

        public BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext)
        {
            this.unitOfWork = unitOfWork;
            this.httpContext = httpContext;
            LoadUser();
        }

        private void LoadUser()
        {
            var user = (User)httpContext.HttpContext.Items["User"];
            email = user?.Id;
        }
    }
}
