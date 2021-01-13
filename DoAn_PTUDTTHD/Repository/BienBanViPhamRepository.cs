using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class BienBanViPhamRepository
    {
        public List<BienBanViPham> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                return db.BienBanViPhams.ToList();
            }
        }
        public List<BienBanViPham> findByBangLai(string soBangLai)
        {
            using (var db = new QLHTGTEntities())
            {
                BangLai bangLai = db.BangLais.Where(b => b.SoBangLai == soBangLai).FirstOrDefault();
                List<BienBanViPham> bienBanViPhams = db.BienBanViPhams.Include("LoiViPhams").Where(b => b.BangLai_id == bangLai.ID).ToList();
                if (bienBanViPhams != null) return bienBanViPhams;
            }
            return null;

        }


    }
}