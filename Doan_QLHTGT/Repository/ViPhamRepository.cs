using Doan_QLHTGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_QLHTGT.Repository
{
    public class ViPhamRepository
    {
        public IEnumerable<ViPham> findAll()
        {
            using (var context = new Context())
            {
                return context.ViPhams.Include("NguoiDangKyXe").ToList();
            }
        }
        public ViPham findById(int id)
        {
            ViPham viPham = null;
            using (var context = new Context())
            {
                viPham = context.ViPhams.Where(n => n.Id == id).FirstOrDefault<ViPham>();
            }
            return viPham;
        }
        public List<ViPham> findByNguoiDangKyXeId(int id)
        {
            List<ViPham> viPhams = null;
            using (var context = new Context())
            {
                viPhams = context.ViPhams.Where(n => n.NguoiDangKyXe.Id == id).ToList();
            }
            return viPhams;
        }
        public void add(ViPham viPham)
        {
            using (var context = new Context())
            {
                context.ViPhams.Add(viPham);
                context.SaveChanges();
            }
        }
    }
}