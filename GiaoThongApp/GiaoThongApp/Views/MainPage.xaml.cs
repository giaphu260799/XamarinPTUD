using GiaoThongApp.Services;
using GiaoThongApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GiaoThongApp.Views
{
    public partial class MainPage : ContentPage
    {
        NguoiDung user = null;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage{
                BindingContext = user
            });
        }
    }
}
