using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class MucPhiCapBienRepository
    {
        public List<MucPhiCapBien> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<MucPhiCapBien> mucPhiCapBiens = db.MucPhiCapBiens.ToList();
                if (mucPhiCapBiens != null)
                    return mucPhiCapBiens;
            }
            return null;
        }
        public MucPhiCapBien findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                MucPhiCapBien mucPhiCapBien = db.MucPhiCapBiens.Where(b => b.ID == id).FirstOrDefault();
                if (mucPhiCapBien != null)
                    return mucPhiCapBien;
            }
            return null;
        }
        public bool addMucPhiCapBien(MucPhiCapBien mucPhiCapBien)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    db.MucPhiCapBiens.Add(mucPhiCapBien);
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
        public bool updateMucPhiCapBien(MucPhiCapBien mucPhiCapBien)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    MucPhiCapBien mucPhiCapBienUpdate = db.MucPhiCapBiens.Find(mucPhiCapBien.ID);
                    if (mucPhiCapBien == null)
                        return false;
                    mucPhiCapBienUpdate.LoaiXe = mucPhiCapBien.LoaiXe;
                    mucPhiCapBienUpdate.KhuVuc = mucPhiCapBien.KhuVuc;
                    mucPhiCapBienUpdate.MucPhi = mucPhiCapBien.MucPhi;
                    mucPhiCapBienUpdate.GiaToiThieu = mucPhiCapBien.GiaToiThieu;
                    mucPhiCapBienUpdate.GiaToiDa = mucPhiCapBien.GiaToiDa;
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
        public bool deleteMucPhiCapBien(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    MucPhiCapBien mucPhiCapBienDel = db.MucPhiCapBiens.Find(id);
                    db.MucPhiCapBiens.Remove(mucPhiCapBienDel);
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