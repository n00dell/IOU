using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IOU.ViewModels
{
    partial class SignUpPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _fullName;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _phoneNumber;
        
        enum UserType
        {
            Student,
            Guardian,
            Administrator
        }

        private UserType _userType;

        [RelayCommand]
        public async void SignUp()
        {

        }
    }
}
