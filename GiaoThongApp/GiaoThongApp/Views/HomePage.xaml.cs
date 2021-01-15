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
    public partial class HomePage : ContentPage
    {
        NguoiDung user = null;
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
            user.Xes = new XeService().GetXeByUser(user);
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
        private void OnImageThongTinCaNhanTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage
            {
                BindingContext = user
            });
        }
        public void OnImageLichSuViPhamTapped(object sender, EventArgs e)
        {
            BienBanViPhamService newService = new BienBanViPhamService();
            List<BienBanViPham> BienBanViPhams = newService.GetViPhamByUser(user);
            Navigation.PushAsync(new DanhSachBienBanViPhamPage
            {
                BindingContext = BienBanViPhams
            });
            /*try
            {
                DisplayAlert("Thông báo", "Nhấn", "Tiếp tục");
            }
            catch (Exception ex)
            {
                throw ex;
            }*/
        }
        public void OnImageDanhSachBangLaiTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DanhSachBangLaiPage
            {
                BindingContext = user
            });
        }
        public void OnImageDanhSachXeTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DanhSachXePage
            {
                BindingContext = user
            });
        }
        public void OnImageDangKyXeTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DangKyXePage
            {
                BindingContext = user
            });
        }
        public void OnImageLichSuDangKyXeTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DanhSachDangKyXePage
            {
                BindingContext = new NguoiDungService().GetUserByID(user.Id)
            });
        }
    }
}
