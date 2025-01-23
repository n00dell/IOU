using IOU.Models;
using System.Web;

namespace IOU.Views;

//[QueryProperty(nameof(FullName), "FullName")]
public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }
    //public string FullName { get; set; }
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    FullNameLabel.Text = FullName;
    //}
}
