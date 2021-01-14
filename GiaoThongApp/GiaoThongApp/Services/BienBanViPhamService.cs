using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    public class BienBanViPhamService
    {
        private readonly string uri = "http://192.168.1.3/api/BienBanViPham";
        public BienBanViPhamService()
        {

        }
        public List<BienBanViPham> GetViPhamByUser(NguoiDung user)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"?nguoiDung_id={user.Id}");
                var result = JsonConvert.DeserializeObject<List<BienBanViPham>>(response.Result.Content.ReadAsStringAsync().Result);
                result.RemoveAll(e => e==null);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public BienBanViPham GetLoiViPhamById(BienBanViPham BienBan)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/GetById?id={BienBan.Id}");
                var result = JsonConvert.DeserializeObject<BienBanViPham>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public bool UpdateBienBan(BienBanViPham bienBan)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(bienBan);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync(uri,data);
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
