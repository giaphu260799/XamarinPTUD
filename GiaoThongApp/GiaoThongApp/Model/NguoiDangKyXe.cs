using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoThongApp.Model
{
    class NguoiDangKyXe
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Status { get; set; }
        public String IdentityCard { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
