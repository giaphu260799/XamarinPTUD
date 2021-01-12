using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Models
{
    public class Xe
    {
        public int Id { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public decimal GiaTien { get; set; }
        public int LoaiXe_id { get; set; }
        public int NguoiDung_id { get; set; }
        public string BienSo { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public LoaiXe LoaiXe { get; set; }
    }
}
