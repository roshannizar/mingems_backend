using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Mingems.Core.Services;
using Mingems.Shared.Core.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;
        private readonly AppSettings options;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> options)
        {
            this.next = next;
            this.options = options.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContext(context, userService, token);

            await next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IUserService userService, string token)
        {
            context.Items["User"] = await userService.GetMetaDataAsync(token);
        }
    }
}
