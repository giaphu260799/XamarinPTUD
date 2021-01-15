using GiaoThongApp.Services;
using GiaoThongApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace GiaoThongApp.Views
{
    public partial class ChiTietYeuCauDangKyXePage : ContentPage
    {
        YeuCauDangKyXe yc = null;
        LoaiXe loaiXe = null;
        public ChiTietYeuCauDangKyXePage()
        {
            InitializeComponent();
        }
        private string ConvertIntToFormatSrting(int num)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = ".";
            string result = num.ToString("N0");

            return result;
        }
        protected override void OnAppearing()
        {
            yc = new YeuCauDangKyXeService().GetYeuCauDangKyXeByID(((YeuCauDangKyXe)BindingContext).Id);
            loaiXe = new LoaiXeService().GetLoaiXeByID(yc.LoaiXe_id);
            if (loaiXe.IsXeOto)
                loai.Text = "Xe ô tô";
            else loai.Text = "Xe máy";
            nhanhieu.Text = loaiXe.NhanHieu;
            mauxe.Text = loaiXe.MauXe;
            mau.Text = loaiXe.Mau;
            namsx.Text = loaiXe.NamSX.ToString();
            trangthai.Text = yc.TrangThai;
            ngayhen.Text = yc.NgayHen.HasValue ? yc.NgayHen.Value.ToString("MMMM dd, yyyy") : string.Empty;
            if (yc.TrangThai == "Chờ thanh toán")
                thanhToanBtn.IsVisible = true;
            else thanhToanBtn.IsVisible = false;
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage
            {
                BindingContext = new NguoiDungService().GetUserByID(yc.NguoiDung_id)
            }) ;
        }
        async void ThanhToanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HoaDonTruocBaPage
            {
                BindingContext = yc
            });

        }
    }
}
