using QLTV.DAO;
using QLTV.DTO;

namespace QLTV.BUS
{
    public class NguoiDungBUS
    {
        public static bool ThemNguoiDung(NguoiDungDTO nguoidung)
        {
            if (NguoiDungDAO.TimNguoiDung(nguoidung.TenDangNhap) != null)
            {
                return false;
            }
            return NguoiDungDAO.ThemNguoiDung(nguoidung);
        }
        public static NguoiDungDTO TimNguoiDung(string tenDangNhap)
        {
            return NguoiDungDAO.TimNguoiDung(tenDangNhap);
        }
        public static bool CapNhatMatKhau(string tendangnhap, string matkhau)
        {
            return NguoiDungDAO.CapNhatMatKhau(tendangnhap, matkhau);
        }
    }
}
