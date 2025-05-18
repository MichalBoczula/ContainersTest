using FluentAssertions;
using PodmanTest.Model;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests
{
    public class WeatherApiTests : IClassFixture<ApplicationFactory>
    {
        private readonly HttpClient _client;

        public WeatherApiTests(ApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_And_Get_WeatherForecast()
        {
            var newForecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Today),
                TemperatureC = 23,
                Summary = "Clear"
            };

            var postResponse = await _client.PostAsJsonAsync("/weather", newForecast);
            postResponse.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/weather");
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var data = await getResponse.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            data.Should().Contain(f => f.Summary == "Clear");
        }
    }
}
