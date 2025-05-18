namespace PodmanTest.Model
{
    public interface IWeatherRepository
    {
        Task<WeatherForecast> CreateAsync(WeatherForecast forecast);
        Task<WeatherForecast?> GetByIdAsync(int id);
        Task<List<WeatherForecast>> GetAllAsync();
        Task<bool> UpdateAsync(WeatherForecast forecast);
        Task<bool> DeleteAsync(int id);
    }
}
