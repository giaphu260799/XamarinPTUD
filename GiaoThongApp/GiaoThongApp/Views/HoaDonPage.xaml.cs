using GiaoThongApp.Services;
using GiaoThongApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HoaDonPage : ContentPage
    {
        BienBanViPham bienBan = null;
        public HoaDonPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            bienBan = (BienBanViPham)BindingContext;
            if(bienBan.HoaDon == null)
            {
                ChiTietHoaDonSL.IsVisible = false;
            }    
            else
            {
                ThanhToanSL.IsVisible = false;
            }
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage
            {
                BindingContext = bienBan.BangLai.NguoiDung
            });
        }
        private void hoanThanh_Clicked(object sender, EventArgs e)
        {
            try
            {
                HoaDon hoaDon = new HoaDon { ThanhTien = bienBan.TongTien, NgayThanhToan = DateTime.Now, BienBanViPham = bienBan };
                HoaDonService createHoaDon = new HoaDonService();
                createHoaDon.CreateHoaDon(hoaDon);
                try
                {
                    DisplayAlert("Thành công", "Nhấn", "Tiếp tục");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}