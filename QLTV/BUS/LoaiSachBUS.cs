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
        public static bool ThemLoaiSach(LoaiSachDTO loaisach)
        {
            return LoaiSachDAO.ThemLoaiSach(loaisach);
        }
        public static bool CapNhatLoaiSach(int maloai, string tenloaimoi)
        {
            return LoaiSachDAO.CapNhatLoaiSach(maloai, tenloaimoi);
        }
        public static bool XoaLoaiSach(int maloai)
        {
            return LoaiSachDAO.XoaLoaiSach(maloai);
        }
    }
}
