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
using System.Windows.Shapes;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DocGiaGUI.xaml
    /// </summary>
    public partial class DocGiaGUI : Window
    {
        public DocGiaGUI()
        {
            InitializeComponent();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            DocGiaDTO docgia = new DocGiaDTO("ID01", hoTenText.Text, diaChiText.Text,
                DateTime.Parse(ngaySinhText.Text), DateTime.Parse(ngayLapTheText.Text), (int)loaiDocGiaCbb.SelectedItem);
            if (DocGiaBUS.ThemDocGia(docgia))
            {
                MessageBox.Show("Thêm độc giả thành công");
            }  
            else MessageBox.Show("Thêm độc giả thất bại");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
