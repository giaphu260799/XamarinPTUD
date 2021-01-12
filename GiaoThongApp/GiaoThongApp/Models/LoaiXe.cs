using System.Collections.Generic;

namespace GiaoThongApp.Models
{
    public class LoaiXe
    {
        public int Id { get; set; }
        public string NhanHieu { get; set; }
        public string MauXe { get; set; }
        public int NamSX { get; set; }
        public List<Xe> Xes { get; set; }
    }
}