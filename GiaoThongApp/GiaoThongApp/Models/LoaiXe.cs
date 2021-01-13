using System.Collections.Generic;

namespace GiaoThongApp.Models
{
    public class LoaiXe
    {
        public int Id { get; set; }
        public bool IsXeOto { get; set; }
        public string NhanHieu { get; set; }
        public string MauXe { get; set; }
        public string Mau { get; set; }
        public int NamSX { get; set; }
        public List<Xe> Xes { get; set; }
    }
}