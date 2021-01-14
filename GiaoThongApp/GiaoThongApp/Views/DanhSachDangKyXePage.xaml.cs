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
    public partial class DanhSachDangKyXePage : ContentPage
    {
        NguoiDung user = null;
        public DanhSachDangKyXePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
            if (user.YeuCauDangKyXes.Count == 0 || user.YeuCauDangKyXes == null)
            {
                img.IsVisible = false;
                YeuCauDangKyXesView.IsVisible = false;
            }
            else
            {
                img_no.IsVisible = false;
                label_no.IsVisible = false;
            }
            YeuCauDangKyXesView.ItemsSource = new NguoiDungService().GetUserByID(user.Id).YeuCauDangKyXes;
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
            YeuCauDangKyXe yc = (YeuCauDangKyXe)lv.SelectedItem;
            Navigation.PushAsync(new ChiTietYeuCauDangKyXePage
            {
                BindingContext = yc
            });
        }
    }
}
