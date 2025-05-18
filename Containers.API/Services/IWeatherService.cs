using PodmanTest.Model;

namespace PodmanTest.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast> CreateAsync(WeatherForecast forecast);
        Task<WeatherForecast?> GetByIdAsync(int id);
        Task<List<WeatherForecast>> GetAllAsync();
        Task<bool> UpdateAsync(WeatherForecast forecast);
        Task<bool> DeleteAsync(int id);
    }
}
