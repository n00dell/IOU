using CommunityToolkit.Mvvm.ComponentModel;

namespace IOU.ViewModels
{
   public partial class DashboardPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal _remainingAmount;

        [ObservableProperty]
        private DateTime _dueDate;

        //[ObservableProperty]
        //[QueryProperty("FullName","FullName")]
        //private string fullName;
        //public DashboardPageViewModel()
        //{
        //    // You can log the FullName here to confirm it's passed correctly
        //}
    }
}
