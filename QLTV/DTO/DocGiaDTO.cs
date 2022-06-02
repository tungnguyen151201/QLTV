using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    public class DocGiaDTO : NguoiDungDTO
    {
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayLapThe { get; set; }
        public int LoaiDocGia { get; set; }
        public DocGiaDTO(string madocgia, string hoten, string diachi, DateTime ngaysinh, DateTime ngaylapthe, int loaidocgia)
        {
            MaDocGia = madocgia;
            HoTen = hoten;
            DiaChi = diachi;
            NgaySinh = ngaysinh;
            NgayLapThe = ngaylapthe;
            LoaiDocGia = loaidocgia;
        }
    }
}
