using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class HinhThucThanhToanRepository
    {
        public List<HinhThucThanhToan> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<HinhThucThanhToan> hinhThucThanhToans = db.HinhThucThanhToans.ToList();
                if (hinhThucThanhToans != null)
                    return hinhThucThanhToans;
            }
            return null;
        }
        public HinhThucThanhToan findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                HinhThucThanhToan hinhThucThanhToan = db.HinhThucThanhToans.Where(b => b.ID == id).FirstOrDefault();
                if (hinhThucThanhToan != null)
                    return hinhThucThanhToan;
            }
            return null;
        }
        public bool addHinhThucThanhToan(HinhThucThanhToan hinhThucThanhToan)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    db.HinhThucThanhToans.Add(hinhThucThanhToan);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }


            }
        }
        public bool updateHinhThucThanhToan(HinhThucThanhToan hinhThucThanhToan)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    HinhThucThanhToan hinhThucThanhToanUpdate = db.HinhThucThanhToans.Find(hinhThucThanhToan.ID);
                    if (hinhThucThanhToan == null)
                        return false;
                    hinhThucThanhToanUpdate.HTTT = hinhThucThanhToan.HTTT;

                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        public bool deleteHinhThucThanhToan(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    HinhThucThanhToan hinhThucThanhToanDel = db.HinhThucThanhToans.Find(id);
                    db.HinhThucThanhToans.Remove(hinhThucThanhToanDel);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}