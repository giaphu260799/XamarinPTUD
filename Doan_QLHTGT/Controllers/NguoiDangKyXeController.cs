using Doan_QLHTGT.Models;
using Doan_QLHTGT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Doan_QLHTGT.Controllers
{
    public class NguoiDangKyXeController : ApiController
    {
        NguoiDangKyXeRepository ng = new NguoiDangKyXeRepository();
        // GET api/values
        public IEnumerable<NguoiDangKyXe> Get()
        {
            return ng.findAll();
        }

        // GET api/values/5
        public NguoiDangKyXe Get(int id)
        {
            return ng.findById(id);
        }

        // POST api/values
        public void Post([FromBody]NguoiDangKyXe nguoiDangKyXe)
        {
            ng.add(nguoiDangKyXe);
        }
        //Get api/NguoiDangKy?identityCard= ""
        public NguoiDangKyXe Get(string identityCard)
        {
            return ng.findByIdentityCard(identityCard);
        }
        // PUT api/values/5
        public bool Put([FromBody]NguoiDangKyXe nguoiDangKy)
        {
            return ng.update(nguoiDangKy);
        }

        // DELETE api/values/5
        public bool Delete(int id)
        {
            return ng.delete(id);
        }
        //Get api/NguoiDangKy
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/NguoiDangKyXe/TaiKhoan")]
        public NguoiDangKyXe GetByTaiKhoanID(int id)
        {
            return ng.findByTaiKhoanId(id);
        }
    }
}