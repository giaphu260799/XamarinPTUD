using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    public class LoaiXeService
    {
        private readonly string uri = "http://192.168.1.3/api/LoaiXe";
        public LoaiXeService()
        {

        }
        public bool CreateLoaiXe(LoaiXe loaixe)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(loaixe);
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
        public LoaiXe GetLoaiXeByID(int id)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/{id}");
                var result = JsonConvert.DeserializeObject<LoaiXe>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public LoaiXe GetLoaiXe(string nhanhieu, string mauxe, string mau, int namsx)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"?nhanhieu={nhanhieu}&mauxe={mauxe}&mau={mau}&namsx={namsx}");
                var result = JsonConvert.DeserializeObject<LoaiXe>(response.Result.Content.ReadAsStringAsync().Result);
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
