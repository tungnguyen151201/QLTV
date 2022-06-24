using QLTV.DAO;
using QLTV.DTO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DocGiaGUI.xaml
    /// </summary>
    public partial class TraCuuSachGUI : Window
    {
        public static int _role;
        public TraCuuSachGUI()
        {
            InitializeComponent();
            list_View.ItemsSource = MuonSachDAO.LoadSach();
        }

        private void muonSachButton_Click(object sender, RoutedEventArgs e)
        {
            /*var button = (FrameworkElement)sender;
            var data = button.Tag;
            int masach = int.Parse(data.ToString());
            int madocgia = 4;// Ma nguoi dung dang nhap

            string ngaymuon = DateTime.Today.ToShortDateString();

            PhieuMuonSachDTO Phieu = new PhieuMuonSachDTO(madocgia,masach, DateTime.Parse(ngaymuon));

            bool check_phieu = MuonSachBUS.MuonSach(Phieu);
            if (check_phieu)
            {
                MessageBox.Show("Mượn thành công !");
            }
            else
            {
                MessageBox.Show("Sách đã được mượn!");
            }*/
            var button = (FrameworkElement)sender;
            var data = button.Tag;
            int masach = int.Parse(data.ToString());
            LapPhieuMuonSach lapPhieuMuonSach = new LapPhieuMuonSach(masach);
            lapPhieuMuonSach.Show();
        }

        private void traCuuButton_Click(object sender, RoutedEventArgs e)
        {

            string str_search = tbxTraCuu.Text;
            List<SachDTO> list_searched = MuonSachDAO.TracuuSach(str_search);
            if (list_searched?.Any() != true)
            {
                MessageBox.Show("Không tìm thấy sách!");
            }
            else
            {
                list_View.ItemsSource = list_searched;

            }
        }

        private void Book_selected(object sender, SelectionChangedEventArgs e)
        {
            var book = (ListView)sender;
            Debug.WriteLine(book.SelectedItem);
        }
    }
}
