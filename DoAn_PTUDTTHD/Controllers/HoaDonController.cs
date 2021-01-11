using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class HoaDonController : ApiController
    {
        HoaDonRepository hoaDonRepository = new HoaDonRepository();
        // GET api/hoadon
        public IEnumerable<HoaDon> Get()
        {
            return hoaDonRepository.findAll();
        }

        // GET api/hoadon/2
        public HoaDon Get(int id)
        {
            return hoaDonRepository.findById(id);
        }

        // POST api/hoadon

        public bool Post([FromBody] HoaDon hoaDon)
        {
            return hoaDonRepository.addHoaDon(hoaDon);
        }

        // PUT api/hoadon

        public bool Put([FromBody] HoaDon hoaDon)
        {
            return hoaDonRepository.updateHoaDon(hoaDon);
        }

        // DELETE api/hoadon/1
        public bool Delete(int id)
        {
            return hoaDonRepository.deleteHoaDon(id);
        }
    }
}
