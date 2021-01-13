using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Models
{
    public class BangLai
    {
        public int Id { get; set; }
        public string Hang { get; set; }
        public DateTime NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string SoBangLai { get; set; }
        public int NguoiDung_id { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public List<BienBanViPham> BienBanViPhams { get; set; }
    }
}
