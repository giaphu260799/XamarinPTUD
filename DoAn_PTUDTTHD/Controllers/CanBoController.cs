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
    public class CanBoController : ApiController
    {
        CanBoRepository canBoRepository = new CanBoRepository();
        //get all
        public IEnumerable<CanBo> Get()
        {
            return canBoRepository.findAll();
        }
        //login
        public CanBo Post(string username,string password)
        {
            return canBoRepository.auth(username, password);
        }

        //Tra cứu thông tin cán bộ
        //Url : api/canbo/tracuucanbo/?username=ahihi
        [HttpGet]
        [Route("api/Canbo/tracuucanbo")]
        public CanBo Get(string username)
        {
            return canBoRepository.findByUsername(username);
        }
        
        
        // POST api/canbo
        public bool Post([FromBody] CanBo canBo)
        {
            return canBoRepository.addCanBo(canBo);
        }

        //PUT api/canbo
        public bool Put([FromBody] CanBo canBo)
        {
            return canBoRepository.updateCanBo(canBo);
        }

        // DELETE api/canbo/1
        //Url : api/canbo/xoacanbo/?username=ahihi
        [HttpDelete]
        [Route("api/Canbo/xoacanbo")]
        public bool Delete(string username)
        {
            return canBoRepository.deleteCanBo(username);
        }

    }
}
