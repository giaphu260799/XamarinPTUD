using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string CMND { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<BangLai> BangLais { get; set;}
        public List<Xe> Xes { get; set; }
        public List<YeuCauDangKyXe> YeuCauDangKyXes { get; set; }
    }
}
