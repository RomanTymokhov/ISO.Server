using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ISO.Server.Services;
using ISO.Server.Services.Implements;

namespace ISO.Server
{
    public class Startup
    {
        private const string isoFilePath = "iso_summary.json";

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var isoconfigBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(isoFilePath);

            Configuration = configuration;
            IsoConfiguration = isoconfigBuilder.Build();
        }

        public IConfiguration Configuration { get; }
        public IConfiguration IsoConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOptions();
            services.Configure<DTO.ISO>(IsoConfiguration);

            services.AddSingleton<IIsoService, IsoService>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
