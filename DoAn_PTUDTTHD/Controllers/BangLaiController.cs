using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class BangLaiController : ApiController
    {
        BangLaiRepository bangLaiRepository = new BangLaiRepository();
        // GET api/BangLai
        public IEnumerable<BangLai> Get()
        {
            return bangLaiRepository.findAll();
        }

        // GET api/BangLai/2
        public BangLai Get(string SoBangLai)
        {
            return bangLaiRepository.findBySoBangLai(SoBangLai);
        }

        // POST api/BangLai
        /* 
            {
                "Hang":"B1",
                "NgayCap":"20/9/2017",
                "NoiCap":"TP HCM",
                "SoBangLai":"21312326",
                "NguoiDung_id":"1"
            }
        */
        public bool Post([FromBody]BangLai bangLai)
        {
            return bangLaiRepository.addBangLai(bangLai);
        }

        // PUT api/BangLai
        /* 
           {
               "Hang":"B1",
               "NgayCap":"20/9/2017",
               "NoiCap":"TP HCM",
               "SoBangLai":"21312326",
               "NguoiDung_id":"1"
           }
       */
        public bool Put([FromBody]BangLai bangLai)
        {
            return bangLaiRepository.updateBangLai(bangLai);
        }

        // DELETE api/BangLai/1
        public bool Delete(int id)
        {
            return bangLaiRepository.deleteBangLai(id);
        }
    }
}
