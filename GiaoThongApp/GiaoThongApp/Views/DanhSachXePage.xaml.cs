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
    public partial class DanhSachXePage : ContentPage
    {
        NguoiDung user = null;
        public DanhSachXePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
            //user.Xes = new XeService().GetXeByUser(user);
            //BindingContext = user as NguoiDung;
            if (user.Xes.Count == 0 || user.Xes == null)
            {
                img.IsVisible = false;
                XesView.IsVisible = false;
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
            Xe xe = (Xe)lv.SelectedItem;
            Navigation.PushAsync(new ChiTietXePage
            {
                BindingContext = xe
            });
        }
        void DangKyXeClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DangKyXePage
            {
                BindingContext = user
            });
        }
    }
}
