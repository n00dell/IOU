

using CommunityToolkit.Mvvm.ComponentModel;

namespace IOU.ViewModels
{
   public partial class DashboardPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal _remainingAmount;

        [ObservableProperty]
        private DateTime _dueDate;

    }
}
