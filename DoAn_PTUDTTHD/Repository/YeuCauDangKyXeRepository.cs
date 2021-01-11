using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class YeuCauDangKyXeRepository
    {
        public List<YeuCauDangKyXe> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<YeuCauDangKyXe> yeuCauDangKyXes = db.YeuCauDangKyXes.ToList();
                if (yeuCauDangKyXes != null)
                    return yeuCauDangKyXes;
            }
            return null;
        }
        public YeuCauDangKyXe findById(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                YeuCauDangKyXe yeuCauDangKyXe = db.YeuCauDangKyXes.Where(b => b.ID == id).FirstOrDefault();
                if (yeuCauDangKyXe != null)
                    return yeuCauDangKyXe;
            }
            return null;
        }
        public bool addYeuCauDangKyXe(YeuCauDangKyXe yeuCauDangKyXe)
        {
            using (var db = new QLHTGTEntities())
            {
                NguoiDung nguoiDung = db.NguoiDungs.Where(n => n.ID == yeuCauDangKyXe.NguoiDung_id).FirstOrDefault();
                LoaiXe loaiXe = db.LoaiXes.Where(n => n.ID == yeuCauDangKyXe.LoaiXe_id).FirstOrDefault();
                MucPhiTruocBa mucPhiTruocBa = db.MucPhiTruocBas.Where(n => n.ID == yeuCauDangKyXe.MPTruocBa_id).FirstOrDefault();
                MucPhiCapBien mucPhiCapBien = db.MucPhiCapBiens.Where(n => n.ID == yeuCauDangKyXe.MPCapBien_id).FirstOrDefault();
                CanBo canBo = db.CanBoes.Where(n => n.ID == yeuCauDangKyXe.CanBo_id).FirstOrDefault();
                if (nguoiDung != null &&
                    loaiXe != null &&
                    mucPhiTruocBa != null &&
                    mucPhiCapBien != null &&
                    canBo != null
                    )
                {
                    try
                    {
                        yeuCauDangKyXe.NguoiDung = nguoiDung;
                        db.YeuCauDangKyXes.Add(yeuCauDangKyXe);
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
        public bool updateYeuCauDangKyXe(YeuCauDangKyXe yeuCauDangKyXe)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    YeuCauDangKyXe yeuCauDangKyXeUpdate = db.YeuCauDangKyXes.Find(yeuCauDangKyXe.ID);
                    if (yeuCauDangKyXe == null)
                        return false;
                    yeuCauDangKyXeUpdate.SoKhung = yeuCauDangKyXe.SoKhung;
                    yeuCauDangKyXeUpdate.SoMay = yeuCauDangKyXe.SoMay;
                    yeuCauDangKyXeUpdate.GiaTien = yeuCauDangKyXe.GiaTien;
                    yeuCauDangKyXeUpdate.NgayHen = yeuCauDangKyXe.NgayHen;
                    yeuCauDangKyXeUpdate.HDTruocBa = yeuCauDangKyXe.HDTruocBa;
                    yeuCauDangKyXeUpdate.HDCapBien = yeuCauDangKyXe.HDCapBien;
                    yeuCauDangKyXeUpdate.NguoiDung_id = yeuCauDangKyXe.NguoiDung_id;
                    yeuCauDangKyXeUpdate.LoaiXe_id = yeuCauDangKyXe.LoaiXe_id;
                    yeuCauDangKyXeUpdate.MPTruocBa_id = yeuCauDangKyXe.MPTruocBa_id;
                    yeuCauDangKyXeUpdate.MPCapBien_id = yeuCauDangKyXe.MPCapBien_id;
                    yeuCauDangKyXeUpdate.CanBo_id = yeuCauDangKyXe.CanBo_id;
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
        public bool deleteYeuCauDangKyXe(int id)
        {
            using (var db = new QLHTGTEntities())
            {
                try
                {
                    YeuCauDangKyXe yeuCauDangKyXeDel = db.YeuCauDangKyXes.Find(id);
                    db.YeuCauDangKyXes.Remove(yeuCauDangKyXeDel);
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