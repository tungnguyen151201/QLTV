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
            if (hoTenText.Text == string.Empty || ngaySinhText.Text == string.Empty || diaChiText.Text == string.Empty
                || emailText.Text == string.Empty || loaiDocGiaCbb.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                NguoiDungDTO nguoidung = new NguoiDungDTO(0, emailText.Text, "123456", DateTime.Parse(ngayLapTheText.Text), 1);
                string loaiDocGia = (string)loaiDocGiaCbb.SelectedItem;
                loaiDocGia = loaiDocGia.Split(" - ")[0];
                if (NguoiDungBUS.ThemNguoiDung(nguoidung))
                {
                    int madocgia = NguoiDungBUS.TimNguoiDung(emailText.Text).MaNguoiDung;
                    DocGiaDTO docgia = new DocGiaDTO(madocgia, hoTenText.Text, diaChiText.Text, emailText.Text,
                    DateTime.Parse(ngaySinhText.Text), DateTime.Parse(ngayLapTheText.Text), int.Parse(loaiDocGia));
                    if (DocGiaBUS.ThemDocGia(docgia))
                    {
                        MessageBox.Show("Thêm độc giả thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                MessageBox.Show("Thêm độc giả thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
