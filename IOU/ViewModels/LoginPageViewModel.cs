using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IOU.Models;
using IOU.Services.Implementations;
using IOU.Services.Interfaces;
using IOU.Views;
using Microsoft.Extensions.Logging;


namespace IOU.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly ILogger<LoginPageViewModel> _logger;
        private readonly IRegistrationService _registrationService;

        public LoginPageViewModel(ILogger<LoginPageViewModel> logger, IRegistrationService registrationService)
        {
            _logger = logger;
            _registrationService = registrationService;
        }

        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

        [RelayCommand]
        public async void Login()
        {
            try
            {
                _logger.LogInformation($"Email: {Email}, Password:{Password}");
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                    User user = await _registrationService.Login(Email, Password);
                    if (user != null)
                    {
                        var appShell = (AppShell)Shell.Current;
                        appShell.SetFullName(user.FullName);
                        // Navigate to the DashboardPage and pass FullName as a query parameter
                        await Shell.Current.GoToAsync(nameof(DashboardPage));
                    }
                    else
                    {
                        _logger.LogError("Invalid Email or Password");
                        await Shell.Current.DisplayAlert("Error", "Invalid Email or Password", "Ok");
                        return;
                    }
                }
                else
                {
                    _logger.LogError("Email and Password are required");
                    await Shell.Current.DisplayAlert("Error", "Email and Password are required", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}
