using QLTV.DAO;
using QLTV.DTO;
using System.Collections.Generic;

namespace QLTV.BUS
{
    public class LoaiDocGiaBUS
    {
        public static List<string> LayDanhSachLoaiDocGia()
        {
            List<string> list = new List<string>();
            foreach (LoaiDocGiaDTO loai in LoaiDocGiaDAO.LayDanhSachLoaiDocGia())
            {
                list.Add(loai.MaLoai + " - " + loai.TenLoai);
            }
            return list;
        }
        public static bool ThemLoaiDocGia(LoaiDocGiaDTO loaidocgia)
        {
            return LoaiDocGiaDAO.ThemLoaiDocGia(loaidocgia);
        }
        public static bool CapNhatLoaiDocGia(int maloai, string tenloaimoi)
        {
            return LoaiDocGiaDAO.CapNhatLoaiDocGia(maloai, tenloaimoi);
        }
        public static bool XoaLoaiDocGia(int maloai)
        {
            return LoaiDocGiaDAO.XoaLoaiDocGia(maloai);
        }
    }
}
