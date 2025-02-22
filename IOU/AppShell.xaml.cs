﻿using IOU.ViewModels;
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
            BindingContext = this;
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(PaymentsPage), typeof(PaymentsPage));
            Routing.RegisterRoute(nameof(SignUp), typeof(SignUp));
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
