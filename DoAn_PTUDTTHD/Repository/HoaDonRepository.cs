using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class HoaDonRepository
    {
        public List<HoaDon> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<HoaDon> hoaDons = db.HoaDons.ToList();
                if (hoaDons != null)
                    return hoaDons;
            }
            return null;
        }
        public HoaDon findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                HoaDon hoaDon = db.HoaDons.Where(b => b.ID == id).FirstOrDefault();
                if (hoaDon != null)
                    return hoaDon;
            }
            return null;
        }
        public bool addHoaDon(HoaDon hoaDon)
        {
            using (var db = new QLHTGTEntities())
            {
                HinhThucThanhToan hinhThucThanhToan = db.HinhThucThanhToans.Where(n => n.ID == hoaDon.HinhThucThanhToan_id).FirstOrDefault();
                if (hinhThucThanhToan != null)
                {
                    try
                    {
                        hoaDon.HinhThucThanhToan = hinhThucThanhToan;
                        db.HoaDons.Add(hoaDon);
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
        public bool updateHoaDon(HoaDon hoaDon)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    HoaDon hoaDonUpdate = db.HoaDons.Find(hoaDon.ID);
                    if (hoaDon == null)
                        return false;
                    hoaDonUpdate.ThanhTien = hoaDon.ThanhTien;
                    hoaDonUpdate.NgayThanhToan = hoaDon.NgayThanhToan;
                    hoaDonUpdate.HinhThucThanhToan_id = hoaDon.HinhThucThanhToan_id;
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
        public bool deleteHoaDon(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    HoaDon hoaDonDel = db.HoaDons.Find(id);
                    db.HoaDons.Remove(hoaDonDel);
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