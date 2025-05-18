using Microsoft.EntityFrameworkCore;
using PodmanTest.Model;

namespace PodmanTest.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WeatherContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Connection")));
            services.AddScoped<IWeatherRepository, WeatherRepository>();

            return services;
        }
    }
}