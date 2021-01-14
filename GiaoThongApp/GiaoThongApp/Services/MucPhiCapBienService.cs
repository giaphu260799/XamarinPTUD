using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    public class MucPhiCapBienService
    {
        private readonly string uri = "http://192.168.1.3/api/MucPhiCapBien";
        public MucPhiCapBienService()
        {

        }
        public MucPhiCapBien GetMucPhiCapBien(int khuvuc, bool loaixe, decimal giatien)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"?loaixe={loaixe}&giatien={giatien}&khuvuc={khuvuc}");
                var result = JsonConvert.DeserializeObject<MucPhiCapBien>(response.Result.Content.ReadAsStringAsync().Result);
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
