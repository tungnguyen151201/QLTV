using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    public class DocGiaDTO
    {
        public int MaDocGia { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayLapThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int LoaiDocGia { get; set; }
        public DateTime NgayHetHan { get; set; }
        public DocGiaDTO(int madocgia, string hoten, string diachi, string email, DateTime ngaysinh, DateTime ngaylapthe, int loaidocgia, DateTime ngayhethan)
        {
            MaDocGia = madocgia;
            HoTen = hoten;
            DiaChi = diachi;
            Email = email;
            NgaySinh = ngaysinh;
            NgayLapThe = ngaylapthe;
            LoaiDocGia = loaidocgia;
            NgayHetHan = ngayhethan;
        }
    }
}
