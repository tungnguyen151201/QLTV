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
    /// Interaction logic for DangKy.xaml
    /// </summary>
    public partial class DangKy : Window
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (tenDangNhapText.Text == string.Empty || matKhauPassword.Password == string.Empty || 
                nhapLaiMatKhauPassword.Password == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(nhapLaiMatKhauPassword.Password != matKhauPassword.Password)
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                NguoiDungDTO nguoidung = new NguoiDungDTO(0, tenDangNhapText.Text, matKhauPassword.Password, DateTime.Parse(DateTime.Today.ToShortDateString()), 0);
                if (NguoiDungBUS.ThemNguoiDung(nguoidung))
                {
                    MessageBox.Show("Đăng ký thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("Đăng ký thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
