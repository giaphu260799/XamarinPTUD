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
                    && !String.IsNullOrEmpty(giatien.Text) && loai.SelectedItem != null)
            {
                user = (NguoiDung)BindingContext;
                YeuCauDangKyXe yc = new YeuCauDangKyXe
                {
                    SoKhung = sokhung.Text,
                    SoMay = somay.Text,
                    GiaTien = Convert.ToDecimal(giatien.Text)
                };
                var loaiXeService = new LoaiXeService();
                var loaiXe = loaiXeService.GetLoaiXe(nhanhieu.Text, mauxe.Text, mau.Text, Convert.ToInt32(namsx.Text));
                yc.NguoiDung_id = user.Id;
                if (loaiXe == null)
                {
                    loaiXe = new LoaiXe();
                    loaiXe.Mau = mau.Text.ToUpper();
                    loaiXe.NhanHieu = nhanhieu.Text.ToUpper();
                    loaiXe.NamSX = Convert.ToInt32(namsx.Text);
                    loaiXe.MauXe = mauxe.Text.ToUpper();
                    if (loai.SelectedItem.ToString() == "Xe máy")
                        loaiXe.IsXeOto = false;
                    else loaiXe.IsXeOto = true;
                    if (loaiXeService.CreateLoaiXe(loaiXe))
                        yc.LoaiXe_id = loaiXeService.GetLoaiXe(nhanhieu.Text, mauxe.Text, mau.Text, Convert.ToInt32(namsx.Text)).Id;
                    else
                    {
                        DisplayAlert("Thông báo", "Nộp yêu cầu đăng ký xe thất bại, vui lòng thử lại", "Tiếp tục");
                        return;
                    }
                }
                else
                    yc.LoaiXe_id = loaiXe.Id;
                yc.TrangThai = "Chờ thanh toán";
                var ycNew = new YeuCauDangKyXeService().CreateYeuCau(yc, user, loaiXe);
                if (ycNew !=null)
                {
                    DisplayAlert("Thông báo", "Nộp yêu cầu đăng ký thành công. Hãy thực hiện thanh toán trước bạ", "Tiếp tục");
                    var previousPage = Navigation.NavigationStack.LastOrDefault();
                    Navigation.PushAsync(new HoaDonTruocBaPage
                    {
                        BindingContext = ycNew
                    });
                    Navigation.RemovePage(previousPage);
                }
                else
                    DisplayAlert("Thông báo", "Nộp yêu cầu đăng ký xe thất bại, vui lòng thử lại", "Tiếp tục");
            }
            else
                DisplayAlert("Thông báo", "Không được để trống", "Tiếp tục");
        }
    }
}