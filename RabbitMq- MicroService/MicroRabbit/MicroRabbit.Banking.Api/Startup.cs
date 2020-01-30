using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Data.DBContext;
using MicroRabbit.Infra.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;


namespace MicroRabbit.Banking.Api
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
            services.AddDbContext<BankingDBContext>(options =>
            {

                options.UseSqlServer(Configuration.GetConnectionString("BankingDbConnection"));
            }
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Banking API Core", Version = "V1" });
              }
            );

            services.AddMediatR(typeof(Startup));
            // (typeof(Startup));
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependancyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
