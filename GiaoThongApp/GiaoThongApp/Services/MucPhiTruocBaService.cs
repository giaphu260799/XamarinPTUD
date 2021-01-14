using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    public class MucPhiTruocBaService
    {
        private readonly string uri = "http://192.168.1.3/api/MucPhiTruocBa";
        public MucPhiTruocBaService()
        {

        }
        public MucPhiTruocBa GetMucPhiTruocBaById(int id)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/{id}");
                var result = JsonConvert.DeserializeObject<MucPhiTruocBa>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public MucPhiTruocBa GetMucPhiTruocBa(int khuvuc, bool loaixe)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"?loaixe={loaixe}&khuvuc={khuvuc}");
                var result = JsonConvert.DeserializeObject<MucPhiTruocBa>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
    }
}
