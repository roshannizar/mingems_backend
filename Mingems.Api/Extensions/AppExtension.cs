using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Infrastructure.DbContexts;
using Mingems.Infrastructure.Repositories;
using Mingems.Infrastructure.Services;
using System;

namespace Mingems.Api.Extensions
{
    public static class AppExtension
    {
        public static void AddAppExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<DbContext, MingemsDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUtilityService, UtilityService>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        }

        public static void AddAppMiddleware(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
