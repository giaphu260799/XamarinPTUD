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
    public partial class ChiTietXePage : ContentPage
    {
        Xe xe = null;
        public ChiTietXePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            xe = (Xe)BindingContext;
        }
        private void LogOut(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void ChangePass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswordPage
            {
                BindingContext = xe.NguoiDung
            });
        }
    }
}
