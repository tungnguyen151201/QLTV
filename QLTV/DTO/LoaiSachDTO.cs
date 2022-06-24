using System.ComponentModel;

namespace QLTV.DTO
{
    public class LoaiSachDTO : INotifyPropertyChanged
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public LoaiSachDTO(int maloai, string tenloai)
        {
            MaLoai = maloai;
            TenLoai = tenloai;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
