using QLTV.BUS;
using QLTV.DTO;
using System;
using System.Windows;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for ThayDoiQuyDinhGUI.xaml
    /// </summary>
    public partial class ThayDoiQuyDinhGUI : Window
    {
        public ThayDoiQuyDinhGUI()
        {
            InitializeComponent();
            tuoiToiThieuText.Text = QuyDinhBUS.TuoiToiThieu().ToString();
            tuoiToiDaText.Text = QuyDinhBUS.TuoiToiDa().ToString();
            thoiHanGiaTriTheText.Text = QuyDinhBUS.ThoiHanGiaTriThe().ToString();
            khoangCachNamXuatBanText.Text = QuyDinhBUS.KhoangCachNamXuatBan().ToString();
            soSachMuonToiDaText.Text = QuyDinhBUS.SoSachMuonToiDa().ToString();
            soNgayMuonToiDaText.Text = QuyDinhBUS.SoNgayMuonToiDa().ToString();
        }

        private void xacNhanButton_Click(object sender, RoutedEventArgs e)
        {
            if (tuoiToiThieuText.Text == string.Empty || tuoiToiDaText.Text == string.Empty || thoiHanGiaTriTheText.Text == string.Empty
               || khoangCachNamXuatBanText.Text == string.Empty || soSachMuonToiDaText.Text == string.Empty || soNgayMuonToiDaText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                QuyDinhDTO quydinh = new QuyDinhDTO(int.Parse(tuoiToiThieuText.Text), int.Parse(tuoiToiDaText.Text),
                    int.Parse(thoiHanGiaTriTheText.Text), int.Parse(khoangCachNamXuatBanText.Text),
                    int.Parse(soSachMuonToiDaText.Text), int.Parse(soNgayMuonToiDaText.Text));
                if (QuyDinhBUS.ThayDoiQuyDinh(quydinh))
                {
                    MessageBox.Show("Thay đổi quy định thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("Thay đổi quy định thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
