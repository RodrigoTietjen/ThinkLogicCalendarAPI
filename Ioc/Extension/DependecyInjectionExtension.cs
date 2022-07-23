using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThinkLogicAPI.Data.Context;
using ThinkLogicAPI.Domain.Interfaces;

namespace ThinkLogicAPI.Ioc.Extensions
{
    public static class DependecyInjectionExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Local"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IAppDbContext, AppDbContext>();
            return services;
        }
    }
}
