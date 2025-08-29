using AutoMapper;
using ConnectSeaApplication.Dto;
using ConnectSeaApplication.Service;
using ConnectSeaRepository.Entities;
using ConnectSeaRepository.Interface;
using Microsoft.Extensions.Logging;
using Moq;

namespace ConnectSeaTests.UnitTests
{
    public class ManifestoServiceTests
    {
        private readonly Mock<IManifestoRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<ManifestoService>> _loggerMock;
        private readonly ManifestoService _service;

        public ManifestoServiceTests()
        {
            _repositoryMock = new Mock<IManifestoRepository>();
            _loggerMock = new Mock<ILogger<ManifestoService>>();
            _mapperMock = new Mock<IMapper>();
            _service = new ManifestoService(_repositoryMock.Object, _loggerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetEscalaAsync_DeveRetornarDtos()
        {
            // Arrange
            var escalas = new List<Escala> { new() { Id = 1, Navio = "MV Poseidon" } };
            var escalasDto = new List<EscalaDto> { new() { Id = 1, Navio = "MV Poseidon" } };

            _repositoryMock.Setup(r => r.GetEscalaAsync()).ReturnsAsync(escalas);
            _mapperMock.Setup(m => m.Map<List<EscalaDto>>(escalas)).Returns(escalasDto);

            // Act
            var result = await _service.GetEscalaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("MV Poseidon", result[0].Navio);

            _repositoryMock.Verify(r => r.GetEscalaAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<EscalaDto>>(escalas), Times.Once);
        }

        [Fact]
        public async Task GetManifestoAsync_DeveRetornarDtos()
        {
            // Arrange
            var manifestos = new List<Manifesto> { new() { Id = 1, Navio = "MV Poseidon" } };
            var manifestosDto = new List<ManifestoDto> { new() { Id = 1, Navio = "MV Poseidon" } };

            _repositoryMock.Setup(r => r.GetManifestoAsync()).ReturnsAsync(manifestos);
            _mapperMock.Setup(m => m.Map<List<ManifestoDto>>(manifestos)).Returns(manifestosDto);

            // Act
            var result = await _service.GetManifestoAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("MV Poseidon", result[0].Navio);

            _repositoryMock.Verify(r => r.GetManifestoAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<ManifestoDto>>(manifestos), Times.Once);
        }

        [Fact]
        public async Task GetManifestoEscalaAsync_DeveRetornarDtos()
        {
            // Arrange
            var manifestosEscalas = new List<ManifestoEscala> { new() { ManifestoId = 1, EscalaId = 301, } };
            var manifestosEscalasDto = new List<ManifestoEscalaDto> { new() { ManifestoId = 1, EscalaId = 301 } };

            _repositoryMock.Setup(r => r.GetManifestoEscalaAsync()).ReturnsAsync(manifestosEscalas);
            _mapperMock.Setup(m => m.Map<List<ManifestoEscalaDto>>(manifestosEscalas)).Returns(manifestosEscalasDto);

            // Act
            var result = await _service.GetManifestoEscalaAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(1, result[0].ManifestoId);
            Assert.Equal(301, result[0].EscalaId);

            _repositoryMock.Verify(r => r.GetManifestoEscalaAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<ManifestoEscalaDto>>(manifestosEscalas), Times.Once);
        }

        [Fact]
        public async Task PostManifestoEscalaAsync_DeveRetornarDtos()
        {
            // Arrange
            var manifestosEscalas = new ManifestoEscala { ManifestoId = 2, EscalaId = 301 };
            var manifestosEscalasDto = new ManifestoEscalaDto { ManifestoId = 2, EscalaId = 301 };

            _repositoryMock.Setup(r => r.PostManifestoEscalaAsync(manifestosEscalas)).ReturnsAsync(manifestosEscalas);
            _mapperMock.Setup(m => m.Map<ManifestoEscala>(manifestosEscalasDto)).Returns(manifestosEscalas);
            _mapperMock.Setup(m => m.Map<ManifestoEscalaDto>(manifestosEscalas)).Returns(manifestosEscalasDto);

            // Act
            var result = await _service.PostManifestoEscalaAsync(manifestosEscalasDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.ManifestoId);
            Assert.Equal(301, result.EscalaId);

            _repositoryMock.Verify(r => r.PostManifestoEscalaAsync(manifestosEscalas), Times.Once);
            _mapperMock.Verify(m => m.Map<ManifestoEscala>(manifestosEscalasDto), Times.Once);
            _mapperMock.Verify(m => m.Map<ManifestoEscalaDto>(manifestosEscalas), Times.Once);
        }
    }
}