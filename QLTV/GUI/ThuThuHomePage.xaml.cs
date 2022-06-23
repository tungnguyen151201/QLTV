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
using System.Windows.Shapes;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for ThuThuHomePage.xaml
    /// </summary>
    public partial class ThuThuHomePage : Window
    {
        public ThuThuHomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DocGiaGUI docGiaGUI = new DocGiaGUI();
            docGiaGUI.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TraCuuSachGUI traCuuSachGUI = new TraCuuSachGUI();
            traCuuSachGUI.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ThayDoiQuyDinhGUI thayDoiQuyDinhGUI = new ThayDoiQuyDinhGUI();
            thayDoiQuyDinhGUI.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TraCuuSachMuonGUI traCuuSachMuonGUI = new TraCuuSachMuonGUI();
            traCuuSachMuonGUI.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            GiaHanTheDocGia giaHanTheDocGia = new GiaHanTheDocGia();
            giaHanTheDocGia.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NhanSachMoiGUI nhanSachMoiGUI = new NhanSachMoiGUI();
            nhanSachMoiGUI.Show();
        }
    }
}
