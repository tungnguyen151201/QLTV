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
    /// Interaction logic for LapPhieuMuonSach.xaml
    /// </summary>
    public partial class LapPhieuMuonSach : Window
    {
        public LapPhieuMuonSach(int masach)
        {
            InitializeComponent();
            maSachText.Text = masach.ToString();
            ngayMuonText.Text = DateTime.Today.ToShortDateString();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (maDocGiaText.Text == string.Empty || maSachText.Text == string.Empty || ngayMuonText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int maDocGia = NguoiDungBUS.TimNguoiDung(maDocGiaText.Text).MaNguoiDung;
                PhieuMuonSachDTO phieuMuonSach = new PhieuMuonSachDTO(maDocGia, Int32.Parse(maSachText.Text), DateTime.Parse(ngayMuonText.Text));
                if (PhieuMuonSachBUS.ThemPhieuMuonSach(phieuMuonSach))
                {
                    MessageBox.Show("Mượn sách thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("Mượn sách thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
