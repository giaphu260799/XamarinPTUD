namespace GiaoThongApp.Models
{
    public class MucPhiCapBien
    {
        public int Id { get; set; }
        public bool LoaiXe { get; set; }
        public int KhuVuc { get; set; }
        public decimal GiaToiThieu { get; set; }
        public decimal GiaToiDa { get; set; }
        public decimal MucPhi { get; set; }
    }
}