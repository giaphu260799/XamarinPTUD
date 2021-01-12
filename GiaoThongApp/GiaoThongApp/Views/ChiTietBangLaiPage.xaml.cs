using GiaoThongApp.Services;
using GiaoThongApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GiaoThongApp.Views
{
    public partial class ChiTietBangLaiPage : ContentPage
    {
        BangLai banglai = null;
        public ChiTietBangLaiPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            banglai = (BangLai)BindingContext;
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage
            {
                BindingContext = banglai.NguoiDung
            });
        }
    }
}
