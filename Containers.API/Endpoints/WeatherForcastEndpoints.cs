using PodmanTest.Model;
using PodmanTest.Services;

namespace PodmanTest.Endpoints
{
    public static class WeatherForcastEndpoints
    {
        public static void MapWeatherEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/weather", async (WeatherForecast forecast, IWeatherService service) =>
            {
                var created = await service.CreateAsync(forecast);
                return Results.Created($"/weather/{created.Id}", created);
            });

            routes.MapGet("/weather", async (IWeatherService service) =>
            {
                var forecasts = await service.GetAllAsync();
                return Results.Ok(forecasts);
            });

            routes.MapGet("/weather/{id:int}", async (int id, IWeatherService service) =>
            {
                var forecast = await service.GetByIdAsync(id);
                return forecast is not null ? Results.Ok(forecast) : Results.NotFound();
            });

            routes.MapPut("/weather/{id:int}", async (int id, WeatherForecast updated, IWeatherService service) =>
            {
                if (id != updated.Id) return Results.BadRequest("ID mismatch");

                var success = await service.UpdateAsync(updated);
                return success ? Results.NoContent() : Results.NotFound();
            });

            routes.MapDelete("/weather/{id:int}", async (int id, IWeatherService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
