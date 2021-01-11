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
    public partial class InfoPage : ContentPage
    {
        NguoiDung user = null;
        public InfoPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage{
                BindingContext = user
            });
        }
    }
}
