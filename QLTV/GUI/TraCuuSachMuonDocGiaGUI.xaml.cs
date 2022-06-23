using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data;
using System.Diagnostics;
using System.Windows.Shapes;
using QLTV.DAO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
