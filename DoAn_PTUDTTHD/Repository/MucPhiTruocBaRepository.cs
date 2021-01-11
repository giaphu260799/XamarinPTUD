using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class MucPhiTruocBaRepository
    {
        public List<MucPhiTruocBa> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<MucPhiTruocBa> mucPhiTruocBas = db.MucPhiTruocBas.ToList();
                if (mucPhiTruocBas != null)
                    return mucPhiTruocBas;
            }
            return null;
        }
        public MucPhiTruocBa findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                MucPhiTruocBa mucPhiTruocBa = db.MucPhiTruocBas.Where(b => b.ID == id).FirstOrDefault();
                if (mucPhiTruocBa != null)
                    return mucPhiTruocBa;
            }
            return null;
        }
        public bool addMucPhiTruocBa(MucPhiTruocBa mucPhiTruocBa)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    db.MucPhiTruocBas.Add(mucPhiTruocBa);
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
        public bool updateMucPhiTruocBa(MucPhiTruocBa mucPhiTruocBa)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    MucPhiTruocBa mucPhiTruocBaUpdate = db.MucPhiTruocBas.Find(mucPhiTruocBa.ID);
                    if (mucPhiTruocBa == null)
                        return false;
                    mucPhiTruocBaUpdate.LoaiXe = mucPhiTruocBa.LoaiXe;
                    mucPhiTruocBaUpdate.KhuVuc = mucPhiTruocBa.KhuVuc;
                    mucPhiTruocBaUpdate.MucPhi = mucPhiTruocBa.MucPhi;
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
        public bool deleteMucPhiTruocBa(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    MucPhiTruocBa mucPhiTruocBaDel = db.MucPhiTruocBas.Find(id);
                    db.MucPhiTruocBas.Remove(mucPhiTruocBaDel);
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