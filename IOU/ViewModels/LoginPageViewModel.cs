using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IOU.Models;
using IOU.Services.Implementations;
using IOU.Services.Interfaces;
using IOU.Views;
using Newtonsoft.Json;


namespace IOU.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

         private readonly IRegistrationService registrationService = new RegistrationService();


        [RelayCommand]
        public async void Login()
        {
            try
            {
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                    
                    if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                    {
                        User user = await registrationService.Login(Email, Password);
                        if (user != null)
                        {
                            
                            var appShell = (AppShell)Shell.Current;
                            appShell.SetFullName(user.FullName);
                            // Navigate to the DashboardPage and pass FullName as a query parameter
                            await Shell.Current.GoToAsync(nameof(DashboardPage));
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Error", "Invalid Email or Password", "Ok");
                            return;
                        }
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Email and Password are required", "Ok");
                        return;
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Email and Password are required", "Ok");
                    return;
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                return;
            }
        }
    }
}
