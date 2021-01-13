﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public BienBanViPham BienBanViPham { get; set; }
    }
}