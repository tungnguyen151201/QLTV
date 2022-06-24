using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Windows;

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
                if (NguoiDungBUS.TimNguoiDung(maDocGiaText.Text) != null)
                {
                    int maDocGia = NguoiDungBUS.TimNguoiDung(maDocGiaText.Text).MaNguoiDung;
                    PhieuMuonSachDTO phieuMuonSach = new PhieuMuonSachDTO(maDocGia, Int32.Parse(maSachText.Text), DateTime.Parse(ngayMuonText.Text));
                    if (PhieuMuonSachBUS.ThemPhieuMuonSach(phieuMuonSach))
                    {
                        MessageBox.Show("Mượn sách thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    MessageBox.Show("Mượn sách thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Không tìm thấy độc giả", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
