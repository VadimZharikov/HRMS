using HRMS.BLL.DI;
using HRMS.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using HRMS.WebApi.DI;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HRMS.WebApi
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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters.ValidateAudience = false;
                o.Authority = "https://localhost:4800";
                o.RequireHttpsMetadata = false;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "ApiScope");
                });
                options.AddPolicy("FrontScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "FrontScope");
                });
                options.AddPolicy("BackFront", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "FrontScope", "ApiScope");
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS.WebApi", Version = "v1" });
            });
            services.AddCors();
            services.AddSerilogServices(new LoggerConfiguration());
            services.AddAutoMapper(Assembly.Load("HRMS.BLL"), Assembly.Load("HRMS.WebApi")
            );
            services.AddFluentValidation();
            services.AddValidatorsFromAssembly(Assembly.Load("HRMS.WebApi"));
            services.AddBusinessLogic(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(op =>
            {
                    op.WithOrigins(
                            "http://localhost:4200"
                        )
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRMS.WebApi v1"));
            }
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
