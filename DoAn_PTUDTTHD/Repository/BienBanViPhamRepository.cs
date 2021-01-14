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
        public List<BienBanViPham> findByNguoiDung(int nguoiDung_id)
        {
            using (var db = new QLHTGTEntities())
            {
                List<BangLai> bangLais = db.BangLais.Where(b => b.NguoiDung_id == nguoiDung_id).ToList();
                List<BienBanViPham> bienBanViPhams = new List<BienBanViPham>();
                foreach (BangLai bangLai in bangLais)
                {
                    List<BienBanViPham> bienBanViPhamOfBangLai = db.BienBanViPhams.Where(b => b.BangLai_id == bangLai.ID).ToList();
                    foreach (BienBanViPham bb in bienBanViPhamOfBangLai)
                    {
                        bienBanViPhams.Add(bb);
                    }

                }
                if (bienBanViPhams != null)
                    return bienBanViPhams;
                return null;
            }
        }
        public BienBanViPham findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                BienBanViPham bienBanViPham = db.BienBanViPhams.Include("LoiViPhams").Where(b => b.ID == id).FirstOrDefault();
                if (bienBanViPham != null) return bienBanViPham;
            }
            return null;
        }

    }
}