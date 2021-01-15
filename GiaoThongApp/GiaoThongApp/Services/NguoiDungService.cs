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
        public NguoiDung GetUserByID(int id)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/{id}");
                var result = JsonConvert.DeserializeObject<NguoiDung>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public NguoiDung CheckUsernamePassword(string username, string password)
        {
            try
            {
                var client = new HttpClient();
                var response = client.PostAsync(uri + $"?username={username}&password={password}", null);
                var result = JsonConvert.DeserializeObject<NguoiDung>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public bool UpdatePass(NguoiDung user)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/DoiMatKhau?id={user.Id}&password={user.Password}");
                var result = JsonConvert.DeserializeObject<bool>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return false;
            }
        }
        public bool CreateUser(NguoiDung user)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(user);
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
