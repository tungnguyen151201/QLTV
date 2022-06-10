using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    public class NguoiDungDTO
    {
        public int MaNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public int LoaiNguoiDung { get; set; }
        public NguoiDungDTO(int manguoidung, string tendangnhap, string matkhau, DateTime ngaytao, int loainguoidung)
        {
            MaNguoiDung = manguoidung;
            TenDangNhap = tendangnhap;
            MatKhau = matkhau;
            NgayTao = ngaytao;
            LoaiNguoiDung = loainguoidung;
        }
    }
}
