using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.IoC;
using Passenger.Infrastructure.IoC.Modules;
using Passenger.Infrastructure.Mappers;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            Configuration.GetSection("Jwt").Bind(new JwtSettings());
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddAuthorization();
            services.AddControllers();
            services.AddJwtAuthorization();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Passenger.Api", Version = "v1" });
            });

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContainerModule(Configuration));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Passenger.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
