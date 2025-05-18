namespace PodmanTest.Services
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            return services;
        }
    }
}
