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
        public YeuCauDangKyXe CreateYeuCau(YeuCauDangKyXe yc, NguoiDung user,LoaiXe loaixe)
        {
            try
            {
                int khuvuc = 0;
                if (user.DiaChi == "Tp.HCM" || user.DiaChi == "Hà Nội")
                    khuvuc = 1;
                else if (user.DiaChi == "Cần Thơ" || user.DiaChi == "Đà Nẵng" || user.DiaChi == "Hải Phòng")
                    khuvuc = 2;
                else khuvuc = 3;
                var mucPhiTruocBa = new MucPhiTruocBaService().GetMucPhiTruocBa(khuvuc, loaixe.IsXeOto);
                if (mucPhiTruocBa == null)
                    return null;
                yc.MPTruocBa_id = mucPhiTruocBa.Id;
                var mucPhiCapBien = new MucPhiCapBienService().GetMucPhiCapBien(khuvuc, loaixe.IsXeOto, yc.GiaTien);
                if (mucPhiCapBien == null)
                    return null;
                yc.MPCapBien_id = mucPhiCapBien.Id;
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(yc);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, data);
                var result = JsonConvert.DeserializeObject<YeuCauDangKyXe>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
        public bool UpdateHDTruocBa(YeuCauDangKyXe yc)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(yc);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync(uri, data);
                var result = JsonConvert.DeserializeObject<bool>(response.Result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return false;
            }
        }
        public YeuCauDangKyXe GetYeuCauDangKyXeByID(int id)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(uri + $"/{id}");
                var result = JsonConvert.DeserializeObject<YeuCauDangKyXe>(response.Result.Content.ReadAsStringAsync().Result);
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
