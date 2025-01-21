using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IOU.Services.Implementations;
using IOU.Services.Interfaces;


namespace IOU.ViewModels
{
    partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

         private readonly IRegistrationService registrationService = new RegistrationService();


        [RelayCommand]
        public async void Login()
        {
        }
    }
}
