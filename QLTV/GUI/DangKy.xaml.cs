using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

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

            if (nhapLaiMatKhauPassword.Password != matKhauPassword.Password)
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                MD5 md = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhauPassword.Password);
                //mã hóa chuỗi đã chuyển
                byte[] hash = md.ComputeHash(inputBytes);
                //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                string hashedPassword = sb.ToString();

                NguoiDungDTO nguoidung = new NguoiDungDTO(0, tenDangNhapText.Text, hashedPassword, DateTime.Parse(DateTime.Today.ToShortDateString()), 0);
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
            Close();
        }
    }
}
