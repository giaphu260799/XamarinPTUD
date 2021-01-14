using System;

namespace GiaoThongApp.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int HinhThucThanhToan_id { get; set; }
        public BienBanViPham BienBanViPham { get; set; }
    }
}