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
    public class TaiKhoanController : ApiController
    {
        TaiKhoanRepository tk = new TaiKhoanRepository();

        // GET: TaiKhoan
        //public ActionResult Index()
        //{
        //    return View();
        //}


        // GET api/values/5
        public TaiKhoan Get(int id)
        {
            return tk.findById(id);
        }

        // GET api/values/username
        public TaiKhoan Post([FromBody]TaiKhoan taiKhoan)
        {
            return tk.findByUsernamePassword(taiKhoan);
        }


        // POST api/values
        /*public void Post([FromBody] TaiKhoan taiKhoan)
        {
            tk.add(taiKhoan);
        }*/

        // PUT api/values/5
        public bool Put([FromBody] TaiKhoan taiKhoan)
        {
            return tk.update(taiKhoan);
        }

        // DELETE api/values/5
        public bool Delete(int id)
        {
            return tk.delete(id);
        }
    }
}