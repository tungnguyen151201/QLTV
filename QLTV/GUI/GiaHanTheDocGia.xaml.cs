using QLTV.BUS;
using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GiaHanTheDocGia.xaml
    /// </summary>
    public partial class GiaHanTheDocGia : Window
    {
        public GiaHanTheDocGia()
        {
            InitializeComponent();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (maDocGiaText.Text == string.Empty || namGiaHanText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                DocGiaDTO docGia = DocGiaBUS.TimDocGia(Int32.Parse(maDocGiaText.Text));
                if (docGia != null)
                {
                    docGia.NgayHetHan = docGia.NgayHetHan.AddYears(Int32.Parse(namGiaHanText.Text));

                    if(DocGiaBUS.CapNhatDocGia(docGia))
                    {
                        MessageBox.Show("Gia hạn thẻ thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                MessageBox.Show("Gia hạn thẻ thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
