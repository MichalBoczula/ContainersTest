using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PodmanTest.Model;

namespace PodmanTest.Infrastructure.Mapping
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.ToTable("WeatherForecasts");

            builder.HasKey(x => x.Id);

            builder.Property(w => w.Date)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(w => w.TemperatureC)
                   .IsRequired();

            builder.Property(w => w.Summary)
                   .HasMaxLength(200);
        }
    }
}
