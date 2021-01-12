using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class XeRepository
    {
        public List<Xe> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<Xe> xes = db.Xes.Include("NguoiDung").Include("LoaiXe").ToList();
                if (xes != null)
                    return xes;
            }
            return null;
        }
        public Xe findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                Xe xe = db.Xes.Include("NguoiDung").Include("LoaiXe").Where(b => b.ID == id).FirstOrDefault();
                if (xe != null)
                    return xe;
            }
            return null;
        }
        public bool addXe(Xe xe)
        {
            using (var db = new QLHTGTEntities())
            {
                NguoiDung nguoiDung = db.NguoiDungs.Where(n => n.ID == xe.NguoiDung_id).FirstOrDefault();
                LoaiXe loaiXe = db.LoaiXes.Where(n => n.ID == xe.LoaiXe_id).FirstOrDefault();
                if (nguoiDung != null && loaiXe != null)
                {
                    try
                    {
                        xe.NguoiDung = nguoiDung;
                        db.Xes.Add(xe);
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
        public bool updateXe(Xe xe)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    Xe xeUpdate = db.Xes.Find(xe.ID);
                    if (xe == null)
                        return false;
                    xeUpdate.SoKhung = xe.SoKhung;
                    xeUpdate.SoMay = xe.SoMay;
                    xeUpdate.NguoiDung_id = xe.NguoiDung_id;
                    xeUpdate.LoaiXe_id = xe.LoaiXe_id;
                    xeUpdate.GiaTien = xe.GiaTien;
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
        public bool deleteXe(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    Xe xeDel = db.Xes.Find(id);
                    db.Xes.Remove(xeDel);
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
        public Xe findByBienSo(string BienSo)
        {
            using (var db = new QLHTGTEntities())
            {
                Xe xe = db.Xes.Include("NguoiDung").Include("LoaiXe").Where(b => b.BienSo == BienSo).FirstOrDefault();
                if (xe != null)
                    return xe;
            }
            return null;
        }

        public List<Xe> findByUserId(int UserId)
        {
            using (var db = new QLHTGTEntities())
            {
                List<Xe> xes = db.Xes.Include("NguoiDung").Include("LoaiXe").Where(b => b.NguoiDung_id == UserId).ToList();
                if (xes != null)
                    return xes;
            }
            return null;
        }
    }
}