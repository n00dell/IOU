using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IOU.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOU.ViewModels
{
    public partial class AppShellViewModel:ObservableObject
    {
        [RelayCommand]
        async void Logout()
        {
            if (Preferences.ContainsKey(nameof(App.user)))
              {
                Preferences.Remove(nameof(App.user));    
            }
            await Shell.Current.GoToAsync($"//{nameof(Login)}"); 
        }
    }
}
