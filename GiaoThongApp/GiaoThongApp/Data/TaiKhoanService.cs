using GiaoThongApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GiaoThongApp.Data
{
    class TaiKhoanService
    {
        private readonly string uri = "http://192.168.1.18/api/TaiKhoan/";
        public TaiKhoanService()
        {

        }

        public TaiKhoan CheckUsernamePassword(TaiKhoan tk)
        {
            if (!String.IsNullOrEmpty(tk.Username) && !String.IsNullOrEmpty(tk.Password))
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(tk);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, data);
                var result = JsonConvert.DeserializeObject<TaiKhoan>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            return null;
        }
        public bool UpdatePass(TaiKhoan tk1)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(tk1);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync(uri, data);
            var result = response.Result.IsSuccessStatusCode;
            return result;
        }
    }
}
