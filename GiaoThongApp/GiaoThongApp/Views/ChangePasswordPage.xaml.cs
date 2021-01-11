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
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
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
                        Navigation.PopToRootAsync();
                    }
                    else
                        DisplayAlert("Thông báo", "Đổi mật khẩu thất bại", "Tiếp tục");
                }
                else
                    DisplayAlert("Thông báo", "Đổi mật khẩu thất bại", "Tiếp tục");
            }
            else
                 DisplayAlert("Thông báo", "Không được để trống!", "Tiếp tục");
        }
    }
}