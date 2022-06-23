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
    public partial class TraCuuSachDocGiaGUI : Window
    {
        public static int _role;
        public TraCuuSachDocGiaGUI()
        {
            InitializeComponent();
            list_View.ItemsSource = MuonSachDAO.LoadSach();  
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
