using System.Net;
using IOU.Models;
using IOU.Services.Implementations;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;

namespace IOU.Tests.Registration
{
    public class RegistrationServiceTests
    {
        
        [Fact]
        public async Task Login_Successful_ShouldReturnUser()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var expectedUser = new User
            {
                Id = "1",
                FullName = "John Doe",
                Email = "johndoe@example.com"
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(expectedUser),
                    System.Text.Encoding.UTF8,
                    "application/json")
            };

            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:7010/")
            };

            var mockLogger = new Mock<ILogger<RegistrationService>>();
            var registrationService = new RegistrationService(httpClient, mockLogger.Object);

            // Act
            var user = await registrationService.Login("johndoe@example.com", "password123");

            // Assert
            Assert.NotNull(user);
            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.FullName, user.FullName);
            Assert.Equal(expectedUser.Email, user.Email);

            mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri.PathAndQuery.Contains("api/user/login")),
                ItExpr.IsAny<CancellationToken>()
            );
        }
        [Fact]
        public async Task Login_InvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Content = new StringContent("Invalid credentials")
            };

            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://localhost:7010/")
            };

            var mockLogger = new Mock<ILogger<RegistrationService>>();
            var registrationService = new RegistrationService(httpClient, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() =>
                registrationService.Login("wrong@email.com", "wrongpassword"));
        }
    }
}
