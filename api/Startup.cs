using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;

namespace api
{
    public class Startup
    {

        private readonly ApiConfig _appSettings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettings = Configuration.Get<ApiConfig>(options => options.BindNonPublicProperties = true);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KmdApi", Version = "v1" });
            });

            DependencyInjections(services, _appSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kmd");
                c.RoutePrefix = string.Empty;
            });
        }

        private void DependencyInjections(IServiceCollection services, ApiConfig appSettings)
        {
            services.AddSingleton<IConnectionHelper>(new ConnectionHelper(appSettings.ConnectionStrings.KmdDb));
            services.AddSingleton<IRepository, Repository>();
        }
    }
}
