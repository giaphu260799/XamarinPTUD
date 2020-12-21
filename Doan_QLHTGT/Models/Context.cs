using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doan_QLHTGT.Models
{
    public class Context : DbContext
    {
        public Context() : base(nameOrConnectionString: "DemoQLHTGTConnection")
        {
            
        }
        public DbSet<NguoiDangKyXe> NguoiDangKyXes { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ViPham> ViPhams { get; set; }
    }
}