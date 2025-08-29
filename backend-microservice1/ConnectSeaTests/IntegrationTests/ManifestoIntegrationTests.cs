using ConnectSeaApplication.Dto;
using ConnectSeaApplication.Interface;
using ConnectSeaApplication.Service;
using ConnectSeaMs1Api.Controllers;
using ConnectSeaRepository.Context;
using ConnectSeaRepository.Interface;
using ConnectSeaRepository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectSeaTests.IntegrationTests
{
    public class ManifestoIntegrationTests
    {
        private readonly ServiceProvider _serviceProvider;

        public ManifestoIntegrationTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "TestDb");
            });
            services.AddTransient<IManifestoRepository, ManifestoRepository>();
            services.AddTransient<IManifestoService, ManifestoService>();
            services.AddTransient<ConnectSeaMs1Controller>();
            services.AddLogging();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task GetEscalaAsync_DeveRetornarEscalas()
        {
            // Arrange
            var manifestoController = _serviceProvider.GetService<ConnectSeaMs1Controller>();

            // Act
            var result = await manifestoController.GetEscalaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);

            var escalas = (result as OkObjectResult)?.Value as IEnumerable<EscalaDto>;
            
            Assert.NotNull(escalas);
            Assert.Single(escalas);
            Assert.Equal(201, escalas.ElementAt(0).Id);
            Assert.Equal("MV Poseidon", escalas.ElementAt(0).Navio);
        }

        [Fact]
        public async Task GetManifestoAsync_DeveRetornarManifestos()
        {
            // Arrange
            var manifestoController = _serviceProvider.GetService<ConnectSeaMs1Controller>();

            // Act
            var result = await manifestoController.GetManifestoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);

            var manifestos = (result as OkObjectResult)?.Value as IEnumerable<ManifestoDto>;
            
            Assert.NotNull(manifestos);
            Assert.Single(manifestos);
            Assert.Equal(1, manifestos.ElementAt(0).Id);
            Assert.Equal("MV Poseidon", manifestos.ElementAt(0).Navio);
        }

        [Fact]
        public async Task GetManifestoEscalaAsync_DeveRetornarManifestosEscalas()
        {
            // Arrange
            var manifestoController = _serviceProvider.GetService<ConnectSeaMs1Controller>();

            // Act
            var result = await manifestoController.GetManifestoEscalaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);

            var manifestosEscalas = (result as OkObjectResult)?.Value as IEnumerable<ManifestoEscalaDto>;

            Assert.NotNull(manifestosEscalas);
            Assert.Equal(1, manifestosEscalas.ElementAt(0).ManifestoId);
            Assert.Equal(201, manifestosEscalas.ElementAt(0).EscalaId);
        }

        [Fact]
        public async Task PostManifestoEscalaAsync_DeveRetornarManifestosEscalas()
        {
            // Arrange
            var manifestoController = _serviceProvider.GetService<ConnectSeaMs1Controller>();

            // Act
            var result = await manifestoController.PostManifestoEscalaAsync(new ManifestoEscalaDto { ManifestoId = 2, EscalaId = 302 });

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);

            var manifestosEscalas = (result as OkObjectResult)?.Value as ManifestoEscalaDto;

            Assert.NotNull(manifestosEscalas);
            Assert.Equal(2, manifestosEscalas.ManifestoId);
            Assert.Equal(302, manifestosEscalas.EscalaId);
        }
    }
}

