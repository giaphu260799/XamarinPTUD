using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiaoThongApp.Models;
using GiaoThongApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoThongApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChiTietBienBanViPhamPage : ContentPage
    {
        BienBanViPham bienBan = null;
        List<LoiViPham> loiViPhams = new List<LoiViPham>();

        public ChiTietBienBanViPhamPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            bienBan = (BienBanViPham)BindingContext;
            BienBanViPhamService newService = new BienBanViPhamService();
            bienBan = newService.GetLoiViPhamById(bienBan);
            loiViPhams = bienBan.LoiViPhams;
            BienBanViPhamView.ItemsSource = loiViPhams;
            if (bienBan.HDNopPhat==null)
            {
                hoaDonBtn.Text = "Thanh toán";
            }
            else
            {
                hoaDonBtn.Text = "Xem hóa đơn";
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

        private void hoaDon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HoaDonPage
            {
                BindingContext = bienBan
            });
        }
    }
}