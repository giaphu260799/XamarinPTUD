using GiaoThongApp.Services;
using GiaoThongApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace GiaoThongApp.Views
{
    public partial class DanhSachBangLaiPage : ContentPage
    {
        NguoiDung user = null;
        public DanhSachBangLaiPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
            if (user.BangLais.Count == 0 || user.BangLais == null)
            {
                img.IsVisible = false;
                BangLaisView.IsVisible = false;
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
            Navigation.PushAsync(new ChangePasswordPage{
                BindingContext = user
            });
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            // this assumes your List is bound to a List<Club>
            BangLai banglai = (BangLai)lv.SelectedItem;
            Navigation.PushAsync(new ChiTietBangLaiPage
            {
                BindingContext = banglai
            });
        }
    }
}
