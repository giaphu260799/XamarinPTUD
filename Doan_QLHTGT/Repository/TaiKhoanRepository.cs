using Doan_QLHTGT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Doan_QLHTGT.Repository
{
    public class TaiKhoanRepository
    {
        public TaiKhoan findById(int id)
        {
            TaiKhoan taiKhoan = null;
            using (var context = new Context())
            {
                taiKhoan = context.TaiKhoans.Where(n => n.Id == id).FirstOrDefault<TaiKhoan>();
            }
            return taiKhoan;
        }
        public IEnumerable<TaiKhoan> findAll()
        {
            using (var context = new Context())
            {
                return context.TaiKhoans.ToList();
            }
        }
        public TaiKhoan findByUsername(string username)
        {
            TaiKhoan taiKhoan = null;
            using (var context = new Context())
            {
                taiKhoan = context.TaiKhoans.Where(n => n.Username == username).FirstOrDefault<TaiKhoan>();
            }
            return taiKhoan;
        }
        public bool update(TaiKhoan taiKhoan)
        {
            TaiKhoan _taiKhoan = null;
            bool _isDone = false;
            using (var context = new Context())
            {
                _taiKhoan = context.TaiKhoans.Where(n => n.Id == taiKhoan.Id)
                     .FirstOrDefault<TaiKhoan>();
                if (_taiKhoan != null)
                {
                    _taiKhoan.Username = taiKhoan.Username;
                    _taiKhoan.Password = taiKhoan.Password;

                    context.Entry<TaiKhoan>(_taiKhoan).State = EntityState.Modified;
                    context.SaveChanges();
                    _isDone = true;
                }
            }
            return _isDone;
        }
        public void add(TaiKhoan taiKhoan)
        {
            using (var context = new Context())
            {
                context.TaiKhoans.Add(taiKhoan);
                context.SaveChanges();
            }
        }
        public bool delete(int id)
        {
            TaiKhoan _taiKhoan = null;
            bool _isDelete = false;
            using (var context = new Context())
            {
                _taiKhoan = context.TaiKhoans.Where(n => n.Id == id)
                     .FirstOrDefault<TaiKhoan>();
                if (_taiKhoan != null)
                {
                    context.Entry<TaiKhoan>(_taiKhoan).State = EntityState.Deleted;
                    context.SaveChanges();
                    _isDelete = true;
                }
            }
            return _isDelete;
        }
        public TaiKhoan findByUsernamePassword(TaiKhoan tk)
        {
            TaiKhoan taiKhoan = null;
            using (var context = new Context())
            {
                taiKhoan = context.TaiKhoans.Where(n => n.Username == tk.Username && n.Password == tk.Password).FirstOrDefault<TaiKhoan>();
            }
            return taiKhoan;
        }
    }
}