using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mingems.Infrastructure.DbContexts;

namespace Mingems.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabaseExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContextPool<MingemsDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MingemsDb"));
            });

            services.AddHangfire(h => h.UseSqlServerStorage(Configuration.GetConnectionString("MingemsDb")));
            services.AddHangfireServer();
        }
    }
}
