using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class BienBanViPhamController : ApiController
    {
        BienBanViPhamRepository bienBanViPhamRepository = new BienBanViPhamRepository();
        // GET api/BienBanViPham
        public IEnumerable<BienBanViPham> Get()
        {
            return bienBanViPhamRepository.findAll();
        }

        // GET api/BienBanViPham?SoBangLai=21312377
        public IEnumerable<BienBanViPham> Get(string soBangLai)
        {
            return bienBanViPhamRepository.findByBangLai(soBangLai);
        }
    }
}
