namespace IOU.Views;
using Microsoft.Maui.Controls;

public partial class SignUp : ContentPage
{
    private string _selectedUserType;
   public SignUp()
    {
        InitializeComponent();

        userPicker.ItemsSource = new List<string> { "Student", "Parent" };
    }
    private async void Signup_Clicked(object sender, EventArgs e)
    {
        if(_selectedUserType == "Student")
        {
            await Navigation.PushAsync(new StudentSignUpPage());
        }
        
    }

    private void userPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker != null && picker.SelectedItem!= null)
        {
            _selectedUserType = picker.SelectedItem.ToString();
            nextButton.IsEnabled= !string.IsNullOrEmpty(_selectedUserType);
        }
    }
}