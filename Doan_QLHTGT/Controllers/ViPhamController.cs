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
    public class ViPhamController : ApiController
    {
        ViPhamRepository viPhamRepo = new ViPhamRepository();
        // GET api/values
        public IEnumerable<ViPham> Get()
        {
            return viPhamRepo.findAll();
        }

        // GET api/values/5
        //public ViPham Get([FromUri] int id)
        //{
        //    return viPhamRepo.findById(id);
        //}

        public IEnumerable<ViPham> Get(int nguoiDangKyXe)
        {
            return viPhamRepo.findByNguoiDangKyXeId(nguoiDangKyXe);
        }

        // POST api/values
        public void Post([FromBody] ViPham viPham)
        {
            viPhamRepo.add(viPham);
        }
    }
}