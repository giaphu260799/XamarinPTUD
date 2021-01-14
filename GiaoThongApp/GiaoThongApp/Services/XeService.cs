using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    public class XeService
    {
        private readonly string uri = "http://192.168.1.3/api/Xe";
        public XeService()
        {

        }
        public List<Xe> GetXeByUser(NguoiDung user)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/XeCuaNguoiDung?UserId={user.Id}");
                var result = JsonConvert.DeserializeObject<List<Xe>>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
    }
}
