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
    public partial class DangKyXePage : ContentPage
    {
        NguoiDung user = null;
        public DangKyXePage()
        {
            InitializeComponent();
        }
        public void DangKyXeClicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(nhanhieu.Text) && !String.IsNullOrEmpty(mauxe.Text)
                && !String.IsNullOrEmpty(namsx.Text) && !String.IsNullOrEmpty(mau.Text)
                   && !String.IsNullOrEmpty(sokhung.Text) && !String.IsNullOrEmpty(somay.Text)
                    && !String.IsNullOrEmpty(giatien.Text) && !String.IsNullOrEmpty(loai.SelectedItem.ToString()))
            {
                user = (NguoiDung)BindingContext;
                YeuCauDangKyXe yc = new YeuCauDangKyXe
                {
                    SoKhung = sokhung.Text,
                    SoMay = somay.Text,
                    GiaTien = Convert.ToDecimal(giatien.Text)
                };
                var loaiXeService = new LoaiXeService();
                yc.LoaiXe = loaiXeService.GetLoaiXe(nhanhieu.Text, mauxe.Text, mau.Text, Convert.ToInt32(namsx.Text));
                yc.NguoiDung_id = user.Id;
                if (yc.LoaiXe == null)
                {
                    yc.LoaiXe = new LoaiXe();
                    yc.LoaiXe.Mau = mau.Text;
                    yc.LoaiXe.NhanHieu = nhanhieu.Text;
                    yc.LoaiXe.NamSX = Convert.ToInt32(namsx.Text);
                    yc.LoaiXe.MauXe = mauxe.Text;
                    if (loaiXeService.CreateLoaiXe(yc.LoaiXe))
                        yc.LoaiXe_id = loaiXeService.GetLoaiXe(nhanhieu.Text, mauxe.Text, mau.Text, Convert.ToInt32(namsx.Text)).Id;
                    else
                    {
                        DisplayAlert("Thông báo", "Nộp yêu cầu đăng ký xe thất bại, vui lòng thử lại", "Tiếp tục");
                        return;
                    }
                }
                else
                    yc.LoaiXe_id = yc.LoaiXe.Id;
                yc.TrangThai = "Chờ thanh toán";
                if (loai.SelectedItem.ToString() == "Xe máy")
                    yc.LoaiXe.IsXeOto = false;
                else yc.LoaiXe.IsXeOto = true;
                var ycService = new YeuCauDangKyXeService();
                if (ycService.CreateYeuCau(yc,user))
                {
                    DisplayAlert("Thông báo", "Nộp yêu cầu đăng ký xe thành công", "Tiếp tục");
                }
                else
                    DisplayAlert("Thông báo", "Nộp yêu cầu đăng ký xe thất bại, vui lòng thử lại", "Tiếp tục");
            }
            else
                DisplayAlert("Thông báo", "Không được để trống", "Tiếp tục");
        }
    }
}