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
    public partial class TraSachGUI : Window
    {
        public TraSachGUI()
        {
            InitializeComponent();
            list_Book_Rental.ItemsSource = TraSachBUS.LoadSach();
         
        }

  
        private void SachMuonSearch_Btn_Click(object sender, RoutedEventArgs e)
        {
            string str_search = tbxTraCuu.Text;

            List<SachDTO> list_searched = TraSachBUS.TraCuuSach(str_search);
            if (list_searched?.Any() != true)
            {
                MessageBox.Show("Không tìm thấy sách!");
            }
            else
            {
                list_Book_Rental.ItemsSource = list_searched;

            }

        }
        private void traSachButton_Click(object sender, RoutedEventArgs e)
        {
            
          var button = (FrameworkElement)sender;
            var tag = button.Tag;
            int masach = int.Parse(tag.ToString());
        
            bool traSach = TraSachDAO.TraSach(masach);
            if (traSach)
            {
                
                MessageBox.Show("Trả sách thành công!");
                list_Book_Rental.ItemsSource = null;
                list_Book_Rental.Items.Clear();
                //// The list<> has been updated so reload the listview [2]
                list_Book_Rental.ItemsSource = TraSachDAO.LoadSachMuon();
                list_Book_Rental.Items.Refresh();
            
 
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
          

        }

    }
}
