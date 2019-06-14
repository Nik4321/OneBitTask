using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneBitTask.Data;
using OneBitTask.Infrastructure.Mapper.Profiles;
using OneBitTask.Repositories;
using OneBitTask.Repositories.Implementations;
using OneBitTask.Services;
using OneBitTask.Services.Implementations;

namespace OneBitTask.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDbContext(services, configuration);
            RegisterServices(services);
            RegisterRepositories(services);
            RegisterAutoMapper(services);
            RegisterMvc(services);
            RegisterHealthCheck(services);
            RegisterCookiePolicy(services);
        }

        private static void RegisterCookiePolicy(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var dbConnString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(dbConnString, builder =>
                {
                    builder.EnableRetryOnFailure(3);
                    builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                }));
        }

        private static void RegisterHealthCheck(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            // Not sure why AppDomain.CurrentDomain.GetAssemblies() does not find the profiles in OneBitTask.Infrastructure
            services.AddAutoMapper(typeof(CustomerProfiles).Assembly);
        }

        private static void RegisterMvc(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}