using System;
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
        async void LoginClicked(object sender, EventArgs e)
        {
            var result = new NguoiDungService().CheckUsernamePassword(username.Text,password.Text);
            if (result != null)
            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = result
                });
            }
            else
            {
                await DisplayAlert("Thông báo", "Đăng nhập thất bại", "Tiếp tục");
            }
        }
        async void SignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DangKyPage());
        }
    }
}