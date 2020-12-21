using Doan_QLHTGT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doan_QLHTGT.Repository
{
    public class NguoiDangKyXeRepository
    {
        public IEnumerable<NguoiDangKyXe> findAll()
        {
            using (var context = new Context())
            {
                return context.NguoiDangKyXes.Include("TaiKhoan").ToList();
            }
        }
        public NguoiDangKyXe findByIdentityCard(string identityCard)
        {
            NguoiDangKyXe nguoiDangKyXe = null;
            using (var context = new Context())
            {
                nguoiDangKyXe = context.NguoiDangKyXes.Where(n => n.IdentityCard == identityCard).FirstOrDefault<NguoiDangKyXe>();
            }
            return nguoiDangKyXe;
        }

        public NguoiDangKyXe findById(int id)
        {
            NguoiDangKyXe nguoiDangKyXe = null;
            using (var context = new Context())
            {
                nguoiDangKyXe = context.NguoiDangKyXes.Where(n => n.Id == id).FirstOrDefault<NguoiDangKyXe>();
            }
            return nguoiDangKyXe;
        }

        internal NguoiDangKyXe findByTaiKhoanId(int id)
        {
            NguoiDangKyXe nguoiDangKyXe = null;
            using (var context = new Context())
            {
                nguoiDangKyXe = context.NguoiDangKyXes.Include("TaiKhoan").Where(n => n.TaiKhoan.Id ==id).FirstOrDefault<NguoiDangKyXe>();
            }
            return nguoiDangKyXe;
        }

        public void add(NguoiDangKyXe nguoiDangKyXe)
        {
            using (var context = new Context())
            {
                context.NguoiDangKyXes.Add(nguoiDangKyXe);
                context.SaveChanges();
            }
        }
        public bool update(NguoiDangKyXe nguoiDangKyXe)
        {
            NguoiDangKyXe _nguoiDangKyXe = null;
            bool _isDone = false;
            using (var context = new Context())
            {
                _nguoiDangKyXe = context.NguoiDangKyXes.Where(n => n.Id == nguoiDangKyXe.Id)
                     .FirstOrDefault<NguoiDangKyXe>();
                if (_nguoiDangKyXe != null)
                {
                    _nguoiDangKyXe.Name = nguoiDangKyXe.Name;
                    _nguoiDangKyXe.Address = nguoiDangKyXe.Address;
                    _nguoiDangKyXe.RegistrationDate = nguoiDangKyXe.RegistrationDate;
                    context.Entry<NguoiDangKyXe>(_nguoiDangKyXe).State = EntityState.Modified;
                    context.SaveChanges();
                    _isDone = true;
                }
            }
            return _isDone;
        }
        public bool delete(int id)
        {
            NguoiDangKyXe _nguoiDangKyXe = null;
            bool _isDelete = false;
            using (var context = new Context())
            {
                _nguoiDangKyXe = context.NguoiDangKyXes.Where(n => n.Id == id)
                     .FirstOrDefault<NguoiDangKyXe>();
                if (_nguoiDangKyXe != null)
                {
                    context.Entry<NguoiDangKyXe>(_nguoiDangKyXe).State = EntityState.Deleted;
                    context.SaveChanges();
                    _isDelete = true;
                }
            }
            return _isDelete;
        }

    }
}