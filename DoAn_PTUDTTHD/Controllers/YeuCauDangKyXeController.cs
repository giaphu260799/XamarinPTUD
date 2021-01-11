using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class YeuCauDangKyXeController : ApiController
    {
        YeuCauDangKyXeRepository yeuCauDangKyXeRepository = new YeuCauDangKyXeRepository();
        // GET api/loaixe
        public IEnumerable<YeuCauDangKyXe> Get()
        {
            return yeuCauDangKyXeRepository.findAll();
        }

        // GET api/loaixe/2
        public YeuCauDangKyXe Get(int id)
        {
            return yeuCauDangKyXeRepository.findById(id);
        }

        // POST api/loaixe

        public bool Post([FromBody] YeuCauDangKyXe yeuCauDangKyXe)
        {
            return yeuCauDangKyXeRepository.addYeuCauDangKyXe(yeuCauDangKyXe);
        }

        // PUT api/loaixe

        public bool Put([FromBody] YeuCauDangKyXe yeuCauDangKyXe)
        {
            return yeuCauDangKyXeRepository.updateYeuCauDangKyXe(yeuCauDangKyXe);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return yeuCauDangKyXeRepository.deleteYeuCauDangKyXe(id);
        }
    }
}
