using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doan_QLHTGT.Models
{
    public class Xe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LoaiXe { get; set; }
        public string BienSo { get; set; }   
        public int ChuSoHuuId { get; set; }
        public NguoiDangKyXe NguoiDangKyXe  {get;set;}  
    }
}