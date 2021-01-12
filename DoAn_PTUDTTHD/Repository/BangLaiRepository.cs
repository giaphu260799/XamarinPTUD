using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class BangLaiRepository
    {
        public List<BangLai> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<BangLai> bangLais = db.BangLais.Include("NguoiDung").ToList();
                if (bangLais != null)
                    return bangLais;
            }
            return null;
        }
        public BangLai findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                BangLai bangLai = db.BangLais.Include("NguoiDung").Where(b => b.ID == id).FirstOrDefault();
                if (bangLai != null)
                    return bangLai;
            }
            return null;
        }
        public bool addBangLai(BangLai bangLai)
        {
            using (var db = new QLHTGTEntities())
            {
                NguoiDung nguoiDung = db.NguoiDungs.Where(n => n.ID == bangLai.NguoiDung_id).FirstOrDefault();
                if(nguoiDung!=null)
                {
                    try
                    {
                        bangLai.NguoiDung = nguoiDung;
                        db.BangLais.Add(bangLai);
                        if (db.SaveChanges() > 0)
                            return true;
                        else return false;
                    }
                    catch
                    {
                        return false;
                    }
                }

            }
            return false;
        }
        public bool updateBangLai(BangLai bangLai)
        {
            using (var db = new QLHTGTEntities())
            {              
                try
                {
                    BangLai bangLaiUpdate = db.BangLais.Find(bangLai.ID);
                    if (bangLai == null)
                        return false;
                    bangLaiUpdate.Hang = bangLai.Hang;
                    bangLaiUpdate.NgayCap = bangLai.NgayCap;
                    bangLaiUpdate.NguoiDung_id = bangLai.NguoiDung_id;
                    bangLaiUpdate.NoiCap = bangLai.NoiCap;
                    bangLaiUpdate.SoBangLai = bangLai.SoBangLai;
                    if (db.SaveChanges() > 0)
                        return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
         
        }
        public bool deleteBangLai(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    BangLai bangLaiDel = db.BangLais.Find(id);
                    db.BangLais.Remove(bangLaiDel);
                    if (db.SaveChanges() > 0)
                        return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        public BangLai findBySoBangLai(string SoBangLai)
        {
            using (var db = new QLHTGTEntities())
            {
                BangLai bangLai = db.BangLais.Include("NguoiDung").Where(b => b.SoBangLai == SoBangLai).FirstOrDefault();
                if (bangLai != null)
                    return bangLai;
            }
            return null;
        }

    }
}