
using evenement.Data;
using Microsoft.EntityFrameworkCore;

namespace evenement.Extensions
{
    public static class AppDataBaseExtensions
    {
        public static IServiceCollection AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
             {
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;

        }

    }
}