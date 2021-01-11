﻿using GiaoThongApp.Services;
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
    public partial class HomePage : ContentPage
    {
        NguoiDung user = null;
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        protected override void OnAppearing()
        {
            user = (NguoiDung)BindingContext;
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
        private void OnImageThongTinCaNhanTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage
            {
                BindingContext = user
            });
        }
        public void OnImageLichSuViPhamTapped(object sender, EventArgs e)
        {

            try
            {
                DisplayAlert("Thông báo", "Nhấn", "Tiếp tục");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
