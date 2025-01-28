using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IOU.Models;
using IOU.Services.Implementations;
using IOU.Services.Interfaces;

namespace IOU.ViewModels
{
   public partial class SignUpPageViewModel : ObservableObject
    {
        private readonly IRegistrationService _registrationService;

        public SignUpPageViewModel(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
            _userTypes = new List<UserType>
            {
                UserType.Student,
                UserType.Guardian,
                UserType.Lender
            };
            SelectedUserType = UserType.Student;
            UpdateVisibility();
        }

        [ObservableProperty]
        private string _fullName;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _phoneNumber;

        [ObservableProperty]
        private UserType _selectedUserType;

        [ObservableProperty]
        private bool _isStudent;

        [ObservableProperty]
        private bool _isGuardian;

        [ObservableProperty]
        private bool _isLender;

        [ObservableProperty]
        private string _studentId;

        [ObservableProperty]
        private string _university;

        [ObservableProperty]
        private DateTime _expectedGraduationDate;

        [ObservableProperty]
        private string _lenderId;

        [ObservableProperty]
        private string _institutionName;

        [ObservableProperty]
        private string _businessRegistrationNumber;

        [ObservableProperty]
        private IEnumerable<UserType> _userTypes;


        partial void OnSelectedUserTypeChanged(UserType value)
        {
            UpdateVisibility();
        }
        

        private void UpdateVisibility()
        {
            IsStudent = SelectedUserType == UserType.Student;
            IsGuardian = SelectedUserType == UserType.Guardian;
            IsLender = SelectedUserType == UserType.Lender;
        }
        [RelayCommand]
        private async Task SignUpAsync()
        {
            var user = new User
            {
                FullName = FullName,
                Email = Email,
                Password = Password,
                PhoneNumber= PhoneNumber
            };
            switch (SelectedUserType)
            {
                case UserType.Student:
                    var student = new Student
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber,
                        University = University,
                        ExpectedGraduationDate = ExpectedGraduationDate
                    };
                    break;
                case UserType.Guardian:
                    var guardian = new Guardian
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber    
                    };
                    var studentGuardian = new StudentGuardian
                    {
                        GuardianId = guardian.Id,
                        StudentId = StudentId
                    };
                    break;
                case UserType.Lender:
                    var lender = new Lender
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber,
                        CompanyName = InstitutionName,
                        BusinessRegistrationNumber = BusinessRegistrationNumber
                    };
                    break;
                case UserType.Administrator:
                    break;
            }
            bool isSuccess = await _registrationService.Register(user);
            if (isSuccess)
            {
                await Shell.Current.DisplayAlert("Success", "User created successfully", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Failed to create user", "OK");
            }
             
        }
    }
}
