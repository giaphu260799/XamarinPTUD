using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class MucPhiTruocBaController : ApiController
    {
        MucPhiTruocBaRepository mucPhiTruocBaRepository = new MucPhiTruocBaRepository();
        // GET api/loaixe
        public IEnumerable<MucPhiTruocBa> Get()
        {
            return mucPhiTruocBaRepository.findAll();
        }

        // GET api/loaixe/2
        public MucPhiTruocBa Get(int id)
        {
            return mucPhiTruocBaRepository.findById(id);
        }

        // POST api/loaixe

        public bool Post([FromBody] MucPhiTruocBa mucPhiTruocBa)
        {
            return mucPhiTruocBaRepository.addMucPhiTruocBa(mucPhiTruocBa);
        }

        // PUT api/loaixe

        public bool Put([FromBody] MucPhiTruocBa mucPhiTruocBa)
        {
            return mucPhiTruocBaRepository.updateMucPhiTruocBa(mucPhiTruocBa);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return mucPhiTruocBaRepository.deleteMucPhiTruocBa(id);
        }
    }
}
