using IOU.Models;

namespace IOU
{
    public partial class App : Application
    {
        public static User user;
        public App()
        {
            //App.Current.UserAppTheme = AppTheme.Dark;
            //App.Current.UserAppTheme = AppTheme.Light;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}