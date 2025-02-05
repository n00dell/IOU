using IOU.Services.Interfaces;
using Moq;
using IOU.ViewModels;
using Microsoft.Extensions.Logging;
using IOU.Models;

namespace IOU.Tests.Registration
{
    public class LoginViewModelTests
    {
        [Fact]
        public async Task Login_Successful_ShouldNavigateToDashboardPage()
        {
            var mockRegistrationService = new Mock<IRegistrationService>();
            var mockLogger = new Mock<ILogger<LoginPageViewModel>>();

            var user = new User
            {
                FullName = "John Doe",
                Email = "johndoe@example.com"
            };
            mockRegistrationService
                .Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(user);
           var viewmodel = new LoginPageViewModel(mockLogger.Object, mockRegistrationService.Object)
           {
               Email = "johndoe@example.com",
               Password = "password123"
           };
            viewmodel.LoginCommand.Execute(null);

            mockRegistrationService.Verify(service => service.Login("johndoe@example.com", "password123"), Times.Once);
        }
        [Fact]
        public async Task Login_Failed_ShouldDisplayError()
        {
            var mockRegistrationService = new Mock<IRegistrationService>();
            var mockLogger = new Mock<ILogger<LoginPageViewModel>>();
            mockRegistrationService
                .Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((User)null);
            var viewmodel = new LoginPageViewModel(mockLogger.Object, mockRegistrationService.Object)
            {
                Email = "invalid@example.com",
                Password = "wrongpassword"
            };
            viewmodel.LoginCommand.Execute(null);

            mockRegistrationService.Verify(service => service.Login("invalid@example.com", "wrongpassword"), Times.Once);
            mockLogger.Verify(logger => logger.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Invalid Email or Password")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once);
        }
    }
}
