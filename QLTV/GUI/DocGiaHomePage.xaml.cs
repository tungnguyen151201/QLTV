using System.Windows;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DocGiaHomePage.xaml
    /// </summary>
    public partial class DocGiaHomePage : Window
    {
        public static string _tendangnhap;
        public DocGiaHomePage(string tendangnhap)
        {
            InitializeComponent();
            _tendangnhap = tendangnhap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TraCuuSachDocGiaGUI muonSachGUI = new TraCuuSachDocGiaGUI();
            muonSachGUI.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TraCuuSachMuonDocGiaGUI traSachGUI = new TraCuuSachMuonDocGiaGUI(_tendangnhap);
            traSachGUI.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(_tendangnhap);
            doiMatKhau.Show();
        }
    }
}
