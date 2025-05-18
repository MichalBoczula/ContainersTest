using Microsoft.EntityFrameworkCore;
using PodmanTest.Infrastructure.Mapping;
using PodmanTest.Model;

namespace PodmanTest.Infrastructure
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherContext(DbContextOptions<WeatherContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherForecastConfiguration());
        }
    }
}
