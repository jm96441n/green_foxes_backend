using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Webdev.TeamFoxesGreen.App.Data;

namespace Webdev.TeamFoxesGreen.App
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configure db context 
            services.AddDbContext<GreenFoxesDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("GreenFoxesDatabase"), 
                    b => b.MigrationsAssembly("green_foxes_backend"))
            );
        
            // Add framework services.
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //allow default document - default.htm(l), index.htm(l)
            app.UseDefaultFiles();

            //allow static files from wwwroot folder
            app.UseStaticFiles();

            //configure mvc
            app.UseMvc();

            //configure cors
            app.UseCors(builder=>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            
        }
    }
}
