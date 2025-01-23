using IOU.ViewModels;
using IOU.Views;

namespace IOU
{
    public partial class AppShell : Shell
    {
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
            BindingContext = this;
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(PaymentsPage), typeof(PaymentsPage));
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {

        }
        public void SetFullName(string fullName)
        {
            FullName = fullName;
        }
    }
}
