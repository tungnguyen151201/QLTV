using QLTV.BUS;
using QLTV.DAO;
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
    /// Interaction logic for NhanSachMoiGUI.xaml
    /// </summary>
    public partial class NhanSachMoiGUI : Window
    {
        public NhanSachMoiGUI()
        {
            InitializeComponent();
            ngayNhapText.Text = DateTime.Today.ToShortDateString();
            loaiSachCbb.ItemsSource = LoaiSachBUS.LayDanhSachLoaiSach();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (tenSachText.Text == string.Empty || tacGiaText.Text == string.Empty || loaiSachCbb.SelectedIndex == -1
                || nhaXuatBanText.Text == string.Empty || namXuatBanText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }    
            int khoangCachNxb = QuyDinhBUS.KhoangCachNamXuatBan();
            try
            {
                int namXuatBan = int.Parse(namXuatBanText.Text);
                if (DateTime.Now.Year - namXuatBan > khoangCachNxb)
                {
                    MessageBox.Show("Khoảng cách năm xuất bản vượt quá quy định", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } 
                else
                {
                    try
                    {
                        string loaiSach = (string)loaiSachCbb.SelectedItem;
                        loaiSach = loaiSach.Split(" - ")[0];
                        SachDTO sach = new SachDTO("0", tenSachText.Text, loaiSach, tacGiaText.Text, namXuatBanText.Text, nhaXuatBanText.Text, ngayNhapText.Text);
                        if (SachBUS.ThemSach(sach))
                        {
                            MessageBox.Show("Thêm sách thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        MessageBox.Show("Thêm sách thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }    
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng điền thông tin hợp lệ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
