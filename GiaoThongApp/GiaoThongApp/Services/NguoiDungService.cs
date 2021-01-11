using GiaoThongApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace GiaoThongApp.Services
{
    public class NguoiDungService
    {
        private readonly string uri = "http://192.168.1.3/api/NguoiDung";
        public NguoiDungService()
        {

        }
        public  NguoiDung CheckUsernamePassword(string username, string password)
        {
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                var client = new HttpClient();
                var response = client.PostAsync(uri + $"?username={username}&password={password}", null);
                var result = JsonConvert.DeserializeObject<NguoiDung>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            return null;
        }
        public bool UpdatePass(NguoiDung user)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync(uri, data);
            var result = response.Result.IsSuccessStatusCode;
            return result;
        }
        public bool CreateUser(NguoiDung user)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync(uri, data);
            var result = response.Result.IsSuccessStatusCode;
            return result;
        }
    }
}
