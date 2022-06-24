using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DoiMatKhau.xaml
    /// </summary>
    public partial class DoiMatKhau : Window
    {
        public static string _tendangnhap;
        public DoiMatKhau(string tendangnhap)
        {
            InitializeComponent();
            _tendangnhap = tendangnhap;
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (matKhauCuPassword.Password == string.Empty || matKhauPassword.Password == string.Empty ||
                nhapLaiMatKhauPassword.Password == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                NguoiDungDTO nguoidung = NguoiDungBUS.TimNguoiDung(_tendangnhap);
                if (nguoidung != null)
                {
                    MD5 md = MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matKhauCuPassword.Password);
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
                        if (nhapLaiMatKhauPassword.Password != matKhauPassword.Password)
                        {
                            MessageBox.Show("Mật khẩu nhập lại không đúng", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        byte[] inputBytes1 = System.Text.Encoding.ASCII.GetBytes(matKhauPassword.Password);
                        //mã hóa chuỗi đã chuyển
                        byte[] hash1 = md.ComputeHash(inputBytes1);
                        //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
                        StringBuilder sb1 = new StringBuilder();

                        for (int i = 0; i < hash1.Length; i++)
                        {
                            sb1.Append(hash1[i].ToString("X2"));
                        }

                        string hashedPassword1 = sb1.ToString();
                        if (NguoiDungBUS.CapNhatMatKhau(_tendangnhap, hashedPassword1))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        return;
                    }
                    MessageBox.Show("Mật khẩu không đúng", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
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
