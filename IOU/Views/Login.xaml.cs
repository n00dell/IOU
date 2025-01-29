using IOU.ViewModels;

namespace IOU.Views;

public partial class Login : ContentPage
{
	public Login(LoginPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

}