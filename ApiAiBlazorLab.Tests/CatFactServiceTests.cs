using Xunit;
using ApiAiBlazorLab.Services;

namespace ApiAiBlazorLab.Tests
{
    public class CatFactServiceTests
    {
        [Fact]
        public async Task GetRandomFact_ValidJson_ReturnsFact()
        {
            // Arrange
            var json = "{\"fact\":\"Cats sleep 16 hours a day.\",\"length\":32}";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act
            var result = await service.GetRandomFactAsync();

            // Assert
            Assert.Equal("Cats sleep 16 hours a day.", result);
        }

        [Fact]
        public async Task GetRandomFact_MissingFactProperty_ReturnsFallback()
        {
            // Arrange
            var json = "{\"length\":32}";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act
            var result = await service.GetRandomFactAsync();

            // Assert
            Assert.Equal("No cat fact received.", result);
        }

        [Fact]
        public async Task GetRandomFact_NullFact_ReturnsFallback()
        {
            // Arrange
            var json = "{\"fact\":null,\"length\":0}";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act
            var result = await service.GetRandomFactAsync();

            // Assert
            Assert.Equal("No cat fact received.", result);
        }

        [Fact]
        public async Task GetRandomFact_InvalidJson_ThrowsException()
        {
            // Arrange
            var json = "not valid json at all";
            var client = new HttpClient(new FakeHandler(json));
            var service = new CatFactService(client);

            // Act & Assert
            await Assert.ThrowsAsync<System.Text.Json.JsonException>(
                async () => await service.GetRandomFactAsync()
            );
        }
    }
}
