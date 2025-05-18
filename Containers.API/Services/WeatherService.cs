using PodmanTest.Model;

namespace PodmanTest.Services
{
    public class WeatherService(IWeatherRepository repo) : IWeatherService
    {
        public async Task<WeatherForecast> CreateAsync(WeatherForecast forecast)
        {
            return await repo.CreateAsync(forecast);
        }

        public async Task<WeatherForecast?> GetByIdAsync(int id)
        {
            return await repo.GetByIdAsync(id);
        }

        public async Task<List<WeatherForecast>> GetAllAsync()
        {
            return await repo.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(WeatherForecast forecast)
        {
            return await repo.UpdateAsync(forecast);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }
    }
}
