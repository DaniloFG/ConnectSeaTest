using ConnectSeaRepository.Context;
using ConnectSeaRepository.Entities;
using ConnectSeaRepository.Service;
using Microsoft.EntityFrameworkCore;

namespace ConnectSeaTests.UnitTests
{
    public class ManifestoRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly ManifestoRepository _manifestoRepository;

        public ManifestoRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _manifestoRepository = new ManifestoRepository(new AppDbContext(_options));

            BuildTables().ConfigureAwait(false);
        }

        private async Task BuildTables()
        {
            using var context = new AppDbContext(_options);
            await context.Escalas.AddAsync(new Escala { Id = 201, Navio = "MV Poseidon" });
            await context.Manifestos.AddAsync(new Manifesto { Id = 1, Navio = "MV Poseidon" });
            await context.ManifestoEscalas.AddAsync(new ManifestoEscala { ManifestoId = 2, EscalaId = 301 });
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetEscalaAsync_DeveRetornarEscalas()
        {
            // Arrange

            // Act
            var result = await _manifestoRepository.GetEscalaAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("MV Poseidon", result[0].Navio);
        }

        [Fact]
        public async Task GetManifestoAsync_DeveRetornarManifestos()
        {
            // Arrange

            // Act
            var result = await _manifestoRepository.GetManifestoAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("MV Poseidon", result[0].Navio);
        }

        [Fact]
        public async Task GetManifestoEscalaAsync_DeveRetornarManifestosEscalas()
        {
            // Arrange

            // Act
            var result = await _manifestoRepository.GetManifestoEscalaAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal(2, result[0].ManifestoId);
            Assert.Equal(301, result[0].EscalaId);
        }

        [Theory]
        [InlineData(2, 301)]
        public async Task GetManifestoEscalaByIdAsync_DeveRetornarManifestosEscalasPorId(int? manifestoId, int? escalaId)
        {
            // Arrange

            // Act
            var result = await _manifestoRepository.GetManifestoEscalaByIdAsync(manifestoId, escalaId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task PostManifestoEscalaAsync_DeveGravarManifestosEscalas()
        {
            // Arrange

            // Act
            var result = await _manifestoRepository.PostManifestoEscalaAsync(new ManifestoEscala { ManifestoId = 1, EscalaId = 201 });

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ManifestoId);
            Assert.Equal(201, result.EscalaId);
        }
    }
}