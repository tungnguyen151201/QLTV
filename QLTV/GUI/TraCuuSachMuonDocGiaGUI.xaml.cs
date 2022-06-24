using QLTV.BUS;
using QLTV.DTO;
using System.Windows;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DocGiaGUI.xaml
    /// </summary>
    public partial class TraCuuSachMuonDocGiaGUI : Window
    {
        public TraCuuSachMuonDocGiaGUI(string tendangnhap)
        {
            InitializeComponent();
            NguoiDungDTO nguoidung = NguoiDungBUS.TimNguoiDung(tendangnhap);
            list_Book_Rental.ItemsSource = TraSachBUS.LoadSach(nguoidung.MaNguoiDung);
        }
    }
}
