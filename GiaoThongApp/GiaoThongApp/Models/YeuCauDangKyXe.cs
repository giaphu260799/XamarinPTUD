using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Models
{
    public class YeuCauDangKyXe
    {
        public int Id { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public Decimal GiaTien { get; set; }
        public DateTime? NgayHen { get; set; }
        public int? HDTruocBa { get; set; }
        public int? HDCapBien { get; set; }
        public int NguoiDung_id { get; set; }
        public int LoaiXe_id { get; set; }
        public int MPTruocBa_id { get; set; }
        public int MPCapBien_id { get; set; }
        public int? CanBo_id { get; set; }
        public string TrangThai { get; set; }
    }
}
