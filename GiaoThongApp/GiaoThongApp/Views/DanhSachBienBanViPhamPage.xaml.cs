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
        public DanhSachBienBanViPhamPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
            if (user.BangLais.Count == 0)
            {
                img.IsVisible = false;
                BienBanViPhamsView.IsVisible = false;
            }
            else
            {
                int viPhamCounter = 0;
                foreach (var bangLai in user.BangLais)
                {
                    if (bangLai.BienBanViPhams.Count != 0)
                    {
                        viPhamCounter++;
                    }
                }
                if (viPhamCounter == 0)
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
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage
            {
                BindingContext = user
            });
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