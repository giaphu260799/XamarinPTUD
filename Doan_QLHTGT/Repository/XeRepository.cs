using Doan_QLHTGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan_QLHTGT.Repository
{
    public class XeRepository
    {
        public IEnumerable<Xe> findAll()
        {
            using (var context = new Context())
            {
                return context.Xes.ToList();
            }
        }
        public Xe findById(int chuSoHuu)
        {
            Xe xe = null;
            using (var context = new Context())
            {
                xe = context.Xes.Where(n => n.ChuSoHuuId == chuSoHuu).FirstOrDefault<Xe>();
            }
            return xe;
        }
        public IEnumerable<Xe> findByChuSoHuu(int chuSoHuu)
        {
            List<Xe> xes;
            using (var context = new Context())
            {
                xes = context.Xes.Where(n => n.ChuSoHuuId == chuSoHuu).ToList();
            }
            return xes;
        }
        //public void add(XeDao xeDao)
        //{
        //    using (var context = new Context())
        //    {
        //        //Xe xe = new Xe(xeDao.LoaiXe, xeDao.BienSo);
        //        //NguoiDangKyXeRepository dangKyXeRepository = new NguoiDangKyXeRepository();
        //        //NguoiDangKyXe nguoiDangKyXe = dangKyXeRepository.findById(xeDao.ChuSoHuu);
        //        //xe.ChuSoHuu = nguoiDangKyXe;
        //        //context.Xes.Add(xe);
        //        //context.SaveChanges();
        //    }
        //}
    }
}