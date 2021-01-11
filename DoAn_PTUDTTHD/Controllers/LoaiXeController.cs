using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class LoaiXeController : ApiController
    {
        LoaiXeRepository loaiXeRepository = new LoaiXeRepository();
        // GET api/loaixe
        public IEnumerable<LoaiXe> Get()
        {
            return loaiXeRepository.findAll();
        }

        // GET api/loaixe/2
        public LoaiXe Get(int id)
        {
            return loaiXeRepository.findById(id);
        }

        // POST api/loaixe

        public bool Post([FromBody] LoaiXe loaiXe)
        {
            return loaiXeRepository.addLoaiXe(loaiXe);
        }

        // PUT api/loaixe

        public bool Put([FromBody] LoaiXe loaiXe)
        {
            return loaiXeRepository.updateLoaiXe(loaiXe);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return loaiXeRepository.deleteLoaiXe(id);
        }
    }
}
