using System.Text;
using System.Text.Json;
using ConnectSeaApplication.Dto;
using ConnectSeaMs1Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ConnectSeaTests.E2ETests
{
    public class ManifestoE2ETests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ManifestoE2ETests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetEscalaAsync_DeveRetornarJsonValido()
        {
            // Act
            var response = await _client.GetAsync("/api/connectseams1/getescala");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var escalas = JsonSerializer.Deserialize<List<EscalaDto>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.NotNull(escalas);
            Assert.True(escalas.Count >= 0);
        }

        [Fact]
        public async Task GetManifestoAsync_DeveRetornarJsonValido()
        {
            // Act
            var response = await _client.GetAsync("/api/connectseams1/getmanifesto");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var manifestos = JsonSerializer.Deserialize<List<ManifestoDto>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.NotNull(manifestos);
            Assert.True(manifestos.Count >= 0);
        }

        [Fact]
        public async Task GetManifestoEscalaAsync_DeveRetornarJsonValido()
        {
            // Act
            var response = await _client.GetAsync("/api/connectseams1/getmanifestoescala");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var manifestosEscalas = JsonSerializer.Deserialize<List<ManifestoEscalaDto>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.NotNull(manifestosEscalas);
            Assert.True(manifestosEscalas.Count >= 0);
        }

        [Fact]
        public async Task PostManifestoEscalaAsync_DeveRetornarJsonValido()
        {
            // Act
            var manifestoEscalaDto = new ManifestoEscalaDto { ManifestoId = 1, EscalaId = 201, DataVinculacao = DateTime.Now };

            var httpContent = JsonSerializer.Serialize(manifestoEscalaDto);

            var response = await _client.PostAsync("/api/connectseams1/postmanifestoescala",
                new StringContent(httpContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var manifestosEscalas = JsonSerializer.Deserialize<ManifestoEscalaDto>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.NotNull(manifestosEscalas);
        }
    }
}