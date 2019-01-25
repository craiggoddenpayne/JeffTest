using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TechTest
{
    public class Startup
    {
        public static Action<IServiceCollection> AdditionalServiceConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            Ioc.Initialise(services);
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            AdditionalServiceConfiguration?.Invoke(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseExceptionHandler("/Error");
            app.UseMvc();
            
        }
    }
}