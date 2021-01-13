using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    class HoaDonService
    {
        private readonly string uri = "http://192.168.1.4/api/HoaDon";
        public HoaDonService()
        {

        }
        public bool CreateHoaDon(HoaDon hoaDon)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(hoaDon);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, data);
                var result = JsonConvert.DeserializeObject<bool>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return false;
            }
        }
    }
}