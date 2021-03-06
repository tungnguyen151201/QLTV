using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (tenDangNhapText.Text == string.Empty || matKhauPassword.Password == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                NguoiDungDTO nguoidung = NguoiDungBUS.TimNguoiDung(tenDangNhapText.Text);
                if (nguoidung != null)
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

                    if (hashedPassword == nguoidung.MatKhau)
                    {
                        if (nguoidung.LoaiNguoiDung == 0)
                        {
                            ThuThuHomePage thuThuHomePage = new ThuThuHomePage();
                            thuThuHomePage.Show();
                        }
                        else
                        {
                            DocGiaHomePage docGiaHomePage = new DocGiaHomePage(nguoidung.TenDangNhap);
                            docGiaHomePage.Show();
                        }
                        Close();
                        return;
                    }

                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("Tài khoản không tồn tại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
