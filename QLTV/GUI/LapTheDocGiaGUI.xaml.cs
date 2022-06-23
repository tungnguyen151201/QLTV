using QLTV.BUS;
using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
            ngayLapTheText.Text = DateTime.Today.ToShortDateString();
            int tuoiToiThieu = QuyDinhBUS.TuoiToiThieu();
            int tuoiToiDa = QuyDinhBUS.TuoiToiDa();
            ngaySinhText.DisplayDateStart = DateTime.Today.AddYears(-tuoiToiDa);
            ngaySinhText.DisplayDateEnd = DateTime.Today.AddYears(-tuoiToiThieu);
            loaiDocGiaCbb.ItemsSource = LoaiDocGiaBUS.LayDanhSachLoaiDocGia();
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
                MD5 md = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes("123456");
                //mã hóa chuỗi đã chuyển
                byte[] hash = md.ComputeHash(inputBytes);
                //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                string hashedPassword = sb.ToString();
                NguoiDungDTO nguoidung = new NguoiDungDTO(0, emailText.Text, hashedPassword, DateTime.Parse(ngayLapTheText.Text), 1);
                string loaiDocGia = (string)loaiDocGiaCbb.SelectedItem;
                loaiDocGia = loaiDocGia.Split(" - ")[0];               
                if (NguoiDungBUS.ThemNguoiDung(nguoidung))
                {
                    int madocgia = NguoiDungBUS.TimNguoiDung(emailText.Text).MaNguoiDung;
                    DocGiaDTO docgia = new DocGiaDTO(madocgia, hoTenText.Text, diaChiText.Text, emailText.Text,
                    DateTime.Parse(ngaySinhText.Text), DateTime.Parse(ngayLapTheText.Text), int.Parse(loaiDocGia),
                    DateTime.Parse(ngayLapTheText.Text).AddYears(QuyDinhBUS.ThoiHanGiaTriThe()));
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

        private void themLoaiDocGiaButton_Click(object sender, RoutedEventArgs e)
        {
            ThemLoaiDocGia themLoaiDocGia = new ThemLoaiDocGia();
            themLoaiDocGia.Show();
        }
    }
}
