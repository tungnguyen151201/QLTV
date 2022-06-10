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


namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DocGiaGUI.xaml
    /// </summary>
    public partial class MuonSachGUI : Window
    {
        public MuonSachGUI()
        {
            InitializeComponent();
            list_View.ItemsSource = MuonSachDAO.LoadSach();

        }
   
        private void muonSachButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (FrameworkElement)sender;
            var data = button.Tag;
            int masach = int.Parse(data.ToString());
            int madocgia = 1;// Ma nguoi dung dang nhap
          
            DateTime ngaymuon = DateTime.Now;
            PhieuMuonSachDTO Phieu = new PhieuMuonSachDTO(madocgia,masach,ngaymuon);


            bool check_phieu = MuonSachDAO.MuonSach(Phieu);
            if (check_phieu)
            {
                MessageBox.Show("Mượn thành công !");
            }
            else
            {
                MessageBox.Show("Sách đã được mượn!");
            }

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
