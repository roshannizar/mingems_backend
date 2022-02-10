using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mingems.Core.Repositories;
using Mingems.Core.Services;
using Mingems.Email.Service;
using Mingems.Infrastructure.DbContexts;
using Mingems.Infrastructure.Repositories;
using Mingems.Infrastructure.Services;
using Mingems.Report.Interfaces;
using Mingems.Report.Services;
using Mingems.Shared.Core.Helpers;
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
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IInvestmentService, InvestmentService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IPrivateCodeService, PrivateCodeService>();

            services.AddTransient<IDashboardService, DashboardService>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            var emailConfig = Configuration
                .GetSection("SendGrid")
                .Get<EmailSenderOptions>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailService, EmailService>();
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
