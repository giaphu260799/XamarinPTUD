using GiaoThongApp.Models;
using GiaoThongApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Brush_Experimental" });
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#00b09b")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
