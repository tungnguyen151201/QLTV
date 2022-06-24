using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Windows;

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
                int madocgia = NguoiDungBUS.TimNguoiDung(maDocGiaText.Text).MaNguoiDung;
                DocGiaDTO docGia = DocGiaBUS.TimDocGia(madocgia);
                if (docGia != null)
                {
                    docGia.NgayHetHan = docGia.NgayHetHan.AddYears(Int32.Parse(namGiaHanText.Text));

                    if (DocGiaBUS.CapNhatDocGia(docGia))
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
