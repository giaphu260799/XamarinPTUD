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
        HoaDonService hoaDonService = null;
        public HoaDonPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            bienBan = (BienBanViPham)BindingContext;
            if(bienBan.HDNopPhat == null)
            {
                ChiTietHoaDonSL.IsVisible = false;
            }    
            else
            {
                int hoaDon_id = (int)bienBan.HDNopPhat;
                hoaDonService = new HoaDonService();
                var hoaDon =  hoaDonService.GetHoaDonByID(hoaDon_id);
                ThanhToanSL.IsVisible = false;
                BindingContext = new { ThanhTien = hoaDon.ThanhTien, NgayThanhToan = hoaDon.NgayThanhToan };
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
                HoaDon hoaDon = new HoaDon { ThanhTien = Convert.ToDecimal(bienBan.TongTien), NgayThanhToan = DateTime.Now, HinhThucThanhToan_id = 1};
                HoaDonService createHoaDon = new HoaDonService();
                var hd = createHoaDon.CreateHoaDon(hoaDon);
                if (hd == null)
                {
                    DisplayAlert("Thành công", "Thanh toán thành công", "Tiếp tục");
                    return;
                }
                bienBan.HDNopPhat = hd.Id;
                //bienBan.HoaDon = hd;
                var htService = new BienBanViPhamService();
                if (htService.UpdateBienBan(bienBan))
                {
                    DisplayAlert("Thành công", "Thanh toán thành công", "Tiếp tục");
                    ThanhToanSL.IsVisible = false;
                    ChiTietHoaDonSL.IsVisible = true;
                    BindingContext = new { ThanhTien = hd.ThanhTien, NgayThanhToan = hd.NgayThanhToan };
                }
                else
                {
                    try
                    {
                        DisplayAlert("Thành công", "Thanh toán thất bại", "Tiếp tục");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
        }
    }
}