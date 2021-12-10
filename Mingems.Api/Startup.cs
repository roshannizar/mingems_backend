using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mingems.Api.Extensions;

namespace Mingems.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationExtension();
            services.AddSecurityExtension(Configuration);
            services.AddDatabaseExtension(Configuration);
            services.AddSwaggerExtension();
            services.AddAppExtension(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AddApplicationMiddleware();
            app.AddSecurityMiddleware();
            app.AddAppMiddleware();
            app.AddSwaggerMiddleware();
        }
    }
}
