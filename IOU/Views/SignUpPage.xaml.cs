namespace IOU.Views;
using Microsoft.Maui.Controls;
using IOU.ViewModels;
using Microsoft.Extensions.DependencyInjection;


public partial class SignUp : ContentPage
{
   
    public SignUp(SignUpPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is SignUpPageViewModel viewModel)
        {
            viewModel.Email = string.Empty;
            viewModel.FullName = string.Empty;
            viewModel.PhoneNumber = string.Empty;
            viewModel.Password = string.Empty;
        }
    }
}
