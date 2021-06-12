using Application.Configure;
using Auth.Configuration;
using Auth.Middleware;
using ErrorHandling.Middleware;
using Infrastructure.Configure;
using Infrastructure.Integration.CSV.Configuration;
using Infrastructure.Integration.CSV.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using System;

namespace movieAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins(Configuration["AllowOrigin"])
                            .WithHeaders(new string[] {"Content-Type", "Authorization"})
                            .WithMethods(new string[] {"GET", "PUT", "POST", "DELETE"});
                    });
            });

            
            services.AddInfrastructureServices();
            services.AddIdentityServices();

            // TODO separate integration from REST API? 
            services.AddIntegrationServices();
            services.AddIntegrationCsvServices(ImportModeEnum.PublicationItem);
            
            services.AddApplicationServices();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.Configure<AuthSettings>(Configuration.GetSection("AuthSettings"));
            services.AddAuthServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "movieAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "movieAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors();

            app.UseAuthentication();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseMiddleware<AuthorizationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddSerilog();
        }
    }
}
