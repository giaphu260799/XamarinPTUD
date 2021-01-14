using GiaoThongApp.Models;
using GiaoThongApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DangKyPage : ContentPage
    {
        public DangKyPage()
        {
            InitializeComponent();
        }
        void SignUpClicked(object sender, EventArgs e)
        {
            NguoiDung user = (NguoiDung)BindingContext;
            if (!String.IsNullOrEmpty(user.Ten) && !String.IsNullOrEmpty(user.Username)
                && !String.IsNullOrEmpty(user.Password) && !String.IsNullOrEmpty(user.GioiTinh)
                   && !String.IsNullOrEmpty(user.DiaChi) && !String.IsNullOrEmpty(user.CMND))
            {
                
                var result = new NguoiDungService().CreateUser(user);
                if (result)
                {
                    DisplayAlert("Thông báo", "Tạo tài khoản thành công, hãy đăng nhập nào", "Tiếp tục");
                    Navigation.PopToRootAsync();
                }
                else
                    DisplayAlert("Thông báo", "Tạo tài khoản thất bại", "Tiếp tục");
            }
            else
                DisplayAlert("Thông báo", "Không được để trống! Vui lòng điền đầy đủ thông tin", "Tiếp tục");
        }
    }
}