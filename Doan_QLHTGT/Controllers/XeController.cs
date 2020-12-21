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
    public class XeController : ApiController
    {
        XeRepository xeRepo = new XeRepository();
        // GET api/values
        //public IEnumerable<XeDao> Get()
        //{
        //    return xeRepo.findAll();
        //}
        public IEnumerable<Xe> Get()
        {
            using (var context = new Context())
            {
                return context.Xes.Include("NguoiDangKyXe").ToList();    
            }
        }



        // GET api/values/5
        public IEnumerable<Xe> Get(int id)
        {
            return xeRepo.findByChuSoHuu(id);
        }

        //// POST api/values
        //public void Post([FromBody]XeDao xeDao)
        //{

        //    xeRepo.add(xeDao);
        //}

        // POST api/values

    }
}