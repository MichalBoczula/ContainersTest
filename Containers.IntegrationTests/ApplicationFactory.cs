using Containers.API;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PodmanTest.Infrastructure;

namespace IntegrationTests
{
    public class ApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private const string Database = "IntegrationTestDb";
        private const string Username = "sa";
        private const string Password = "yourStrong(!)Password";
        private const ushort MsSqlPort = 1433;

        private readonly IContainer _mssqlContainer;

        public ApplicationFactory()
        {
            _mssqlContainer = new ContainerBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPortBinding(MsSqlPort, true)
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithEnvironment("SQLCMDUSER", Username)
                .WithEnvironment("SQLCMDPASSWORD", Password)
                .WithEnvironment("MSSQL_SA_PASSWORD", Password)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(MsSqlPort))
                .Build();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var host = _mssqlContainer.Hostname;
            var port = _mssqlContainer.GetMappedPublicPort(MsSqlPort);

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<WeatherContext>));

                services.AddDbContext<WeatherContext>(options =>
                    options.UseSqlServer(
                        $"Server={host},{port};Database={Database};User Id={Username};Password={Password};TrustServerCertificate=True"));
            });
        }

        public async Task InitializeAsync()
        {
            await _mssqlContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _mssqlContainer.DisposeAsync();
        }
    }
}