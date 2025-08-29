using ConnectSeaApplication.Dto;
using ConnectSeaApplication.Interface;
using ConnectSeaMs1Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace ConnectSeaTests.UnitTests
{
    public class ConnectSeaMs1ControllerTests
    {
        private readonly Mock<IManifestoService> _manifestoServiceMock;
        private readonly Mock<ILogger<ConnectSeaMs1Controller>> _loggerMock;
        private readonly ConnectSeaMs1Controller _controller;

        public ConnectSeaMs1ControllerTests()
        {
            _manifestoServiceMock = new Mock<IManifestoService>();
            _loggerMock = new Mock<ILogger<ConnectSeaMs1Controller>>();
            _controller = new ConnectSeaMs1Controller(_loggerMock.Object, _manifestoServiceMock.Object);
        }

        [Fact]
        public async Task GetEscalaAsync_DeveRetornarEscalas()
        {
            // Arrange
            var escalas = new List<EscalaDto> { new() { Id = 1, Navio = "MV Poseidon" } };

            _manifestoServiceMock.Setup(m => m.GetEscalaAsync()).ReturnsAsync(escalas);

            // Act
            var result = await _controller.GetEscalaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.Equal(escalas, (result as OkObjectResult)?.Value);

            _manifestoServiceMock.Verify(m => m.GetEscalaAsync(), Times.Once);
        }

        [Fact]
        public async Task GetManifestoAsync_DeveRetornarManifestos()
        {
            // Arrange
            var manifestos = new List<ManifestoDto> { new() { Id = 1, Navio = "MV Poseidon" } };

            _manifestoServiceMock.Setup(m => m.GetManifestoAsync()).ReturnsAsync(manifestos);

            // Act
            var result = await _controller.GetManifestoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.Equal(manifestos, (result as OkObjectResult)?.Value);

            _manifestoServiceMock.Verify(m => m.GetManifestoAsync(), Times.Once);
        }

        [Fact]
        public async Task GetManifestoEscalaAsync_DeveRetornarManifestosEscalas()
        {
            // Arrange
            var manifestosEscalas = new List<ManifestoEscalaDto> { new() { ManifestoId = 2, EscalaId = 301 } };

            _manifestoServiceMock.Setup(m => m.GetManifestoEscalaAsync()).ReturnsAsync(manifestosEscalas);

            // Act
            var result = await _controller.GetManifestoEscalaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.Equal(manifestosEscalas, (result as OkObjectResult)?.Value);

            _manifestoServiceMock.Verify(m => m.GetManifestoEscalaAsync(), Times.Once);
        }

        [Fact]
        public async Task PostManifestoEscalaAsync_DeveRetornarManifestosEscalas()
        {
            // Arrange
            var manifestoEscalaDto = new ManifestoEscalaDto { ManifestoId = 2, EscalaId = 301 };

            _manifestoServiceMock.Setup(m => m.PostManifestoEscalaAsync(manifestoEscalaDto)).ReturnsAsync(manifestoEscalaDto);

            // Act
            var result = await _controller.PostManifestoEscalaAsync(manifestoEscalaDto);

            // Assert
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
            Assert.Equal(manifestoEscalaDto, (result as OkObjectResult)?.Value);

            _manifestoServiceMock.Verify(m => m.PostManifestoEscalaAsync(manifestoEscalaDto), Times.Once);
        }
    }
}

