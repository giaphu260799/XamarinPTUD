using DoAn_PTUDTTHD.Models;
using DoAn_PTUDTTHD.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace DoAn_PTUDTTHD.Controllers
{
    public class XeController : ApiController
    {
        XeRepository xeRepository = new XeRepository();
        HoaDonRepository hoaDonRepository = new HoaDonRepository();
        YeuCauDangKyXeRepository yeuCauDangKyXeRepository = new YeuCauDangKyXeRepository();

        // GET api/xe
        public IEnumerable<Xe> Get()
        {
            return xeRepository.findAll();
        }

        // GET api/xe/2 
        public Xe Get(int id)
        {
            return xeRepository.findById(id);
        }

        // POST api/xe
     
        public bool Post([FromBody] Xe xe)
        {
            return xeRepository.addXe(xe);
        }

        // PUT api/xe
        
        public bool Put([FromBody] Xe xe)
        {
            return xeRepository.updateXe(xe);
        }

        // DELETE api/xe/1
        public bool Delete(int id)
        {
            return xeRepository.deleteXe(id);
        }

        //Tra cứu biển số xe
        //Url : api/Xe/TraCuuBienSo/?BienSo=81B1-32135
        [HttpGet]
        [Route("api/Xe/TraCuuBienSo")]
        public Xe Get(string BienSo)
        {
            return xeRepository.findByBienSo(BienSo);
        }

        //Xem danh sách xe theo người dùng
        //Url : api/Xe/XeCuaNguoiDung/?UserId=12
        [HttpGet]
        [Route("api/Xe/XeCuaNguoiDung")]
        public List<Xe> GetByUserId(int UserId)
        {
            return xeRepository.findByUserId(UserId);
        }


        //Đang ký xe
        //Url : api/Xe/DangKyXe
        //Body : DangKyXeInput
        public class DangKyXeInput
        {
            public HoaDon hoaDon { get; set; }
            public YeuCauDangKyXe yeuCauDangKyXe { get; set; }
        }

        [HttpGet]
        [Route("api/Xe/DangKyXe")]
        public string DangKyXe([FromBody] DangKyXeInput dangKyXeInput)
        {
            hoaDonRepository.addHoaDon(dangKyXeInput.hoaDon);
            yeuCauDangKyXeRepository.addYeuCauDangKyXe(dangKyXeInput.yeuCauDangKyXe);

            return string.Format("{0:HH:mm:ss tt}", DateTime.Now.AddDays(2));
        }
    }
}
