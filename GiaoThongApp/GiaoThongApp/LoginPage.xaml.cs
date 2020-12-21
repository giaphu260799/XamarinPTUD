using GiaoThongApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GiaoThongApp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void LoginClicked(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)BindingContext;
            var result = new TaiKhoanService().CheckUsernamePassword(tk);
            if (result != null)
            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = result
                }) ;
            }
            else
            {
                await DisplayAlert("Thông báo", "Đăng nhập thất bại", "Tiếp tục");
            }
        }

    }
}