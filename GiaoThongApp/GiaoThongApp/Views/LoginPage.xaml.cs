using System;
using GiaoThongApp.Models;
using GiaoThongApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            username.Text = "";
            password.Text = "";
        }
        async void LoginClicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(username.Text) && !String.IsNullOrEmpty(password.Text))
            {
                var result = new NguoiDungService().CheckUsernamePassword(username.Text, password.Text);
                if (result != null)
                {
                    await Navigation.PushAsync(new HomePage
                    {
                        BindingContext = result
                    });
                }
                else
                {
                    await DisplayAlert("Thông báo", "Đăng nhập thất bại", "Tiếp tục");
                }
            }
            else
            {
                await DisplayAlert("Thông báo", "Không được để trống username/password!", "Tiếp tục");
            }
        }
        async void SignUpTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DangKyPage
            {
                BindingContext = new NguoiDung()
            }
            );
        }
    }
}