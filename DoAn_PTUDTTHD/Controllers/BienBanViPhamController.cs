using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class BienBanViPhamController : ApiController
    {
        BienBanViPhamRepository bienBanViPhamRepository = new BienBanViPhamRepository();
        // GET api/loaixe
        public IEnumerable<BienBanViPham> Get()
        {
            return bienBanViPhamRepository.findAll();
        }

        // GET api/loaixe/2
        public BienBanViPham Get(int id)
        {
            return bienBanViPhamRepository.findById(id);
        }

        // POST api/loaixe

        public bool Post([FromBody] BienBanViPham bienBanViPham)
        {
            return bienBanViPhamRepository.addBienBanViPham(bienBanViPham);
        }

        // PUT api/loaixe

        public bool Put([FromBody] BienBanViPham bienBanViPham)
        {
            return bienBanViPhamRepository.updateBienBanViPham(bienBanViPham);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return bienBanViPhamRepository.deleteBienBanViPham(id);
        }
    }
}
