using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Karambolo.Extensions.Logging.File;
using LogNativoExemplo.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LogNativoExemplo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // services.AddLogging(lb =>
            // {
            //     lb.AddConfiguration(Configuration.GetSection("Logging"));
            //     lb.AddFile(new FileLoggerContext(AppContext.BaseDirectory, "minha-app.log"));
            // });

            services.AddTransient<ValuesController>((ctx) =>
            {
                var contexto = ctx.GetRequiredService<ILogger<ValuesController>>();
                return new ValuesController(contexto);
            });

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(Configuration.GetSection("Logging"));
                builder.AddFile(o => o.RootPath = AppContext.BaseDirectory);
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
