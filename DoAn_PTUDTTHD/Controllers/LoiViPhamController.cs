using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class LoiViPhamController : ApiController
    {
        LoiViPhamRepository loiViPhamRepository = new LoiViPhamRepository();
        //get all
        public IEnumerable<LoiViPham> Get()
        {
            return loiViPhamRepository.findAll();
        }
    }
}