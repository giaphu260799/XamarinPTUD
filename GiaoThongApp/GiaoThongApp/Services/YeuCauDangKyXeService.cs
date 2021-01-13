using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    class YeuCauDangKyXeService
    {
        private readonly string uri = "http://192.168.1.3/api/YeuCauDangKyXe";
        public YeuCauDangKyXeService()
        {

        }
        public bool CreateYeuCau(YeuCauDangKyXe yc,NguoiDung user)
        {
            try
            {
                int temp = 0;
                if (yc.LoaiXe.IsXeOto)
                    temp = 3;
                if (user.DiaChi == "Tp.HCM" || user.DiaChi == "Hà Nội")
                    yc.MPTruocBa_id = 1 + temp;
                else if (user.DiaChi == "Cần Thơ" || user.DiaChi == "Đà Nẵng" || user.DiaChi == "Hải Phòng")
                    yc.MPTruocBa_id = 2 + temp;
                else yc.MPTruocBa_id = 3 + temp;
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(yc);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, data);
                var result = JsonConvert.DeserializeObject<bool>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return false;
            }
        }
    }
}
