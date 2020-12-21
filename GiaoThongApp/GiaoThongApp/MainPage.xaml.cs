using GiaoThongApp.Data;
using GiaoThongApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GiaoThongApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        protected override void OnAppearing()
        {
            TaiKhoan tk = (TaiKhoan)BindingContext;
            BindingContext = new NguoiDangKyXeService().ShowInfo(tk);
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage { BindingContext = new TaiKhoan() });
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword{
                BindingContext = BindingContext
            });
        }
    }
}
