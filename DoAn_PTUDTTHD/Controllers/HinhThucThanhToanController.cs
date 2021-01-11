using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class HinhThucThanhToanController : ApiController
    {
        HinhThucThanhToanRepository hinhThucThanhToanRepository = new HinhThucThanhToanRepository();
        // GET api/loaixe
        public IEnumerable<HinhThucThanhToan> Get()
        {
            return hinhThucThanhToanRepository.findAll();
        }

        // GET api/loaixe/2
        public HinhThucThanhToan Get(int id)
        {
            return hinhThucThanhToanRepository.findById(id);
        }

        // POST api/loaixe

        public bool Post([FromBody] HinhThucThanhToan hinhThucThanhToan)
        {
            return hinhThucThanhToanRepository.addHinhThucThanhToan(hinhThucThanhToan);
        }

        // PUT api/loaixe

        public bool Put([FromBody] HinhThucThanhToan hinhThucThanhToan)
        {
            return hinhThucThanhToanRepository.updateHinhThucThanhToan(hinhThucThanhToan);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return hinhThucThanhToanRepository.deleteHinhThucThanhToan(id);
        }
    }
}
