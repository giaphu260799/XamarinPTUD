using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class MucPhiCapBienController : ApiController
    {
        MucPhiCapBienRepository mucPhiCapBienRepository = new MucPhiCapBienRepository();
        // GET api/loaixe
        public IEnumerable<MucPhiCapBien> Get()
        {
            return mucPhiCapBienRepository.findAll();
        }

        // GET api/loaixe/2
        public MucPhiCapBien Get(int id)
        {
            return mucPhiCapBienRepository.findById(id);
        }

        // POST api/loaixe

        public bool Post([FromBody] MucPhiCapBien mucPhiCapBien)
        {
            return mucPhiCapBienRepository.addMucPhiCapBien(mucPhiCapBien);
        }

        // PUT api/loaixe

        public bool Put([FromBody] MucPhiCapBien mucPhiCapBien)
        {
            return mucPhiCapBienRepository.updateMucPhiCapBien(mucPhiCapBien);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return mucPhiCapBienRepository.deleteMucPhiCapBien(id);
        }
    }
}
