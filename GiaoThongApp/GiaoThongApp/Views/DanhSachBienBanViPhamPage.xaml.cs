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
    public partial class DanhSachBienBanViPhamPage : ContentPage
    {
        NguoiDung user = null;

        List<BienBanViPham> BienBanViPhams = new List<BienBanViPham>();

        public DanhSachBienBanViPhamPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BienBanViPhams = (List<BienBanViPham>)BindingContext;
            if (BienBanViPhams.Count != 0)
            {
                user = BienBanViPhams.FirstOrDefault().BangLai.NguoiDung;
            }
            BienBanViPhamsView.ItemsSource = BienBanViPhams;
            this.BindingContext = BienBanViPhams as List<BienBanViPham>;
            if (BienBanViPhams.Count == 0)
            {
                img.IsVisible = false;
                BienBanViPhamsView.IsVisible = false;
            }
            else
            {
                img_no.IsVisible = false;
                label_no.IsVisible = false;
            }
        }
            
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            if (user != null)
            {
                Navigation.PushAsync(new ChangePasswordPage
                {
                    BindingContext = user
                });
            }
            else
            {
                try
                {
                    DisplayAlert("Không được đổi mật khẩu", "Không được đổi mật khẩu", "Tiếp tục");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            // this assumes your List is bound to a List<Club>
            BienBanViPham bienBan = (BienBanViPham)lv.SelectedItem;
            Navigation.PushAsync(new ChiTietBienBanViPhamPage
            {
                BindingContext = bienBan
            });
        }
    }
}