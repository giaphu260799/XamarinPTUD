using GiaoThongApp.Services;
using GiaoThongApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void ChangePass(object sender, EventArgs e)
        {
            NguoiDung user = (NguoiDung)BindingContext;
            if (!String.IsNullOrEmpty(old_pass.Text) && !String.IsNullOrEmpty(new_pass1.Text) && String.Equals(new_pass1.Text, new_pass2.Text))
            {
                var check = user.Password.Equals(old_pass.Text);
                if(check)
                {
                    user.Password = new_pass1.Text;
                    var result = new NguoiDungService().UpdatePass(user);
                    if (result)
                    {
                        DisplayAlert("Thông báo", "Đổi mật khẩu thành công, vui lòng đăng nhập lại", "Tiếp tục");
                        Navigation.PushAsync(new LoginPage { BindingContext = new NguoiDung() });
                    }
                    else
                        DisplayAlert("Thông báo", "Đổi mật khẩu thất bại", "Tiếp tục");
                }
                else
                    DisplayAlert("Thông báo", "Đổi mật khẩu thất bại", "Tiếp tục");
            }
            else
                 DisplayAlert("Thông báo", "Đổi mật khẩu thất bại", "Tiếp tục");
        }
        private void Profile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage
            {
                BindingContext = BindingContext
            }
            );
        }
    }
}