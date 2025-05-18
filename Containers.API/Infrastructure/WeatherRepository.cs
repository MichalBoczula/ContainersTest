using Microsoft.EntityFrameworkCore;
using PodmanTest.Model;

namespace PodmanTest.Infrastructure
{
    public class WeatherRepository(WeatherContext context) : IWeatherRepository
    {
        public async Task<WeatherForecast> CreateAsync(WeatherForecast forecast)
        {
            context.WeatherForecasts.Add(forecast);
            await context.SaveChangesAsync();
            return forecast;
        }

        public async Task<WeatherForecast?> GetByIdAsync(int id)
        {
            return await context.WeatherForecasts.FindAsync(id);
        }

        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            return await context.WeatherForecasts.ToListAsync();
        }

        public async Task<bool> UpdateAsync(WeatherForecast forecast)
        {
            var existing = await context.WeatherForecasts.FindAsync(forecast.Id);
            if (existing == null) return false;

            existing.Date = forecast.Date;
            existing.TemperatureC = forecast.TemperatureC;
            existing.Summary = forecast.Summary;

            context.Update(existing);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var forecast = await context.WeatherForecasts.FindAsync(id);
            if (forecast == null) return false;

            context.WeatherForecasts.Remove(forecast);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
