using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class LoaiXeRepository
    {
        public List<LoaiXe> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<LoaiXe> loaiXes = db.LoaiXes.ToList();
                if (loaiXes != null)
                    return loaiXes;
            }
            return null;
        }
        public LoaiXe findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                LoaiXe loaiXe = db.LoaiXes.Where(b => b.ID == id).FirstOrDefault();
                if (loaiXe != null)
                    return loaiXe;
            }
            return null;
        }
        public bool addLoaiXe(LoaiXe loaiXe)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    db.LoaiXes.Add(loaiXe);
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
        public bool updateLoaiXe(LoaiXe loaiXe)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    LoaiXe loaiXeUpdate = db.LoaiXes.Find(loaiXe.ID);
                    if (loaiXe == null)
                        return false;
                    loaiXeUpdate.NhanHieu = loaiXe.NhanHieu;
                    loaiXeUpdate.MauXe = loaiXe.MauXe;
                    loaiXeUpdate.NamSX = loaiXe.NamSX;
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
        public bool deleteLoaiXe(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    LoaiXe loaiXeDel = db.LoaiXes.Find(id);
                    db.LoaiXes.Remove(loaiXeDel);
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
    }
}