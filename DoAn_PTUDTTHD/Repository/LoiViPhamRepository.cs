using DoAn_PTUDTTHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_PTUDTTHD.Repository
{
    public class LoiViPhamRepository
    {
        public List<LoiViPham> findAll()
        {
            using (var db = new QLHTGTEntities())
            {
                List<LoiViPham> loiViPhams = db.LoiViPhams.ToList();
                if (loiViPhams != null)
                    return loiViPhams;
            }
            return null;
        }
    }
}