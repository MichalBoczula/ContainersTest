using PodmanTest.Endpoints;
using PodmanTest.Infrastructure;
using PodmanTest.Services;

namespace Containers.API
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistance(builder.Configuration);
            builder.Services.AddApplication();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapWeatherEndpoints();

            app.Run();
        }
    }
}
