using GiaoThongApp.Data;
using GiaoThongApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage { BindingContext = new TaiKhoan() });
        }

        private void ChangePass(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)BindingContext;
            if (!String.IsNullOrEmpty(old_pass.Text) && !String.IsNullOrEmpty(new_pass1.Text) && String.Equals(new_pass1.Text, new_pass2.Text))
            {
                var check = tk.Password.Equals(old_pass.Text);
                if(check)
                {
                    tk.Password = new_pass1.Text;
                    var result = new TaiKhoanService().UpdatePass(tk);
                    if (result)
                    {
                        DisplayAlert("Thông báo", "Đổi mật khẩu thành công, vui lòng đăng nhập lại", "Tiếp tục");
                        Navigation.PushAsync(new LoginPage { BindingContext = new TaiKhoan() });
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
            Navigation.PushAsync(new MainPage());
        }
    }
}