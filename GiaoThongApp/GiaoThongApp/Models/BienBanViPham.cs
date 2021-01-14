using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Models
{
    public class BienBanViPham
    {
        public int Id { get; set; }
        public decimal TongTien { get; set; }
        public int TongDiemTru { get; set; }
        public DateTime ThoiGianViPham { get; set; }
        public BangLai BangLai { get; set; }
        public List<LoiViPham> LoiViPhams { get; set; }
        public int? HDNopPhat { get; set; }
        //public HoaDon HoaDon { get; set; }
    }
}
