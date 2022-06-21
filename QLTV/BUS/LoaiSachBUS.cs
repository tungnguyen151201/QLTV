using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BUS
{
    class LoaiSachBUS
    {
        public static List<string> LayDanhSachLoaiSach()
        {
            List<string> list = new List<string>();
            foreach (LoaiSachDTO loai in LoaiSachDAO.LayDanhSachLoaiSach())
            {
                list.Add(loai.MaLoai + " - " + loai.TenLoai);
            }
            return list;
        }
    }
}
