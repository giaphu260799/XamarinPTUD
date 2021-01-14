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
    public partial class HoaDonTruocBaPage : ContentPage
    {
        YeuCauDangKyXe yc = null;
        MucPhiTruocBaService mucPhiTruocBa = new MucPhiTruocBaService();
        HoaDonService hoaDonService = new HoaDonService();
        public HoaDonTruocBaPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            yc = (YeuCauDangKyXe)BindingContext;
            if (yc.HDTruocBa == null)
            {
                ThanhToanSL.IsVisible = true;
                ChiTietHoaDonSL.IsVisible = false;
            }
            else
            {
                ThanhToanSL.IsVisible = false;
                ChiTietHoaDonSL.IsVisible = true;
            }
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        private void hoanThanh_Clicked(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var giaTienTruocBa = Convert.ToDecimal(Convert.ToUInt32(Convert.ToUInt32(yc.GiaTien) * (Convert.ToDouble(mucPhiTruocBa.GetMucPhiTruocBaById(yc.MPTruocBa_id).MucPhi) / 100)));
                    var hoaDonTruocBa = new HoaDon
                    {
                        ThanhTien = giaTienTruocBa,
                        NgayThanhToan = DateTime.Now,
                        HinhThucThanhToan_id = 1
                    };
                    var hd = hoaDonService.CreateHoaDon(hoaDonTruocBa);
                    if (hd == null)
                    {
                        DisplayAlert("Thành công", "Thanh toán thất bại", "Tiếp tục");
                        return;
                    }
                    else
                    {
                        yc.HDTruocBa = hd.Id;
                        yc.TrangThai = "Chờ duyệt";
                        yc.NgayHen = hd.NgayThanhToan.AddDays(3);
                    }
                    var ycService = new YeuCauDangKyXeService();
                    if (ycService.UpdateHDTruocBa(yc))
                    {
                        DisplayAlert("Thành công", "Thanh toán thành công", "Tiếp tục");
                        thanhtien.Text = $"{String.Format("{0:##,##}",Convert.ToUInt32(hd.ThanhTien))} VNĐ";
                        ngayhen.Text = hd.NgayThanhToan.AddDays(3).ToString("MMMM dd, yyyy");
                        ngaytt.Text= hd.NgayThanhToan.ToString("MMMM dd, yyyy");
                        OnAppearing();
                    }
                    else DisplayAlert("Thành công", "Thanh toán thất bại", "Tiếp tục");
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