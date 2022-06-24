using System.ComponentModel;

namespace QLTV.DTO
{
    public class SachDTO : INotifyPropertyChanged
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string NamXuatBan { get; set; }
        public string NhaXuatBan { get; set; }
        public string NgayNhap { get; set; }

        public SachDTO(string masach, string tensach, string theloai, string tacgia, string namXB, string NXB, string ngaynhap)
        {
            MaSach = masach;
            TenSach = tensach;
            TheLoai = theloai;
            TacGia = tacgia;
            NamXuatBan = namXB;
            NhaXuatBan = NXB;
            NgayNhap = ngaynhap;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
