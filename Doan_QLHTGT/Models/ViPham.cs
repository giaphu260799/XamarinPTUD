using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_QLHTGT.Models
{
    public class ViPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NoiDung { get; set; }
        public int TienPhat { get; set; }
        public DateTime NgayViPham { get; set; }
        public NguoiDangKyXe NguoiDangKyXe { get; set; }
    }
}