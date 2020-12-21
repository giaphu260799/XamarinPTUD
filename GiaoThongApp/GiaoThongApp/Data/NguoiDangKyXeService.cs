using GiaoThongApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GiaoThongApp.Data
{
    class NguoiDangKyXeService
    {
        private readonly string uri = "http://192.168.1.18/api/NguoiDangKyXe/";
        public NguoiDangKyXeService()
        {

        }
        public NguoiDangKyXe ShowInfo(TaiKhoan tk)
        {
            var client = new HttpClient();
            var url = uri + "TaiKhoan?id=" + tk.Id.ToString();
            var response =  client.GetStringAsync(url);
            //var content = await response.
            var r = JsonConvert.DeserializeObject<NguoiDangKyXe>(response.Result);
            return r;
        }
    }
}
