using QLTV.BUS;
using QLTV.DAO;
using QLTV.DTO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for ThemLoaiDocGia.xaml
    /// </summary>
    public partial class ThemLoaiDocGia : Window
    {
        BindingList<LoaiDocGiaDTO> list;
        public ThemLoaiDocGia()
        {
            InitializeComponent();
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var index = myListView.SelectedIndex;
            loaiDocGiaText.Text = list[index].TenLoai;
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
            var index = myListView.SelectedIndex;
            if (index != -1)
            {
                LoaiDocGiaDTO loai = list[index];
                if (LoaiDocGiaBUS.XoaLoaiDocGia(loai.MaLoai))
                {
                    list.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn loại độc giả cần xóa", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void themButton_Click(object sender, RoutedEventArgs e)
        {
            if (loaiDocGiaText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên loại độc giả", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoaiDocGiaDTO loai = new LoaiDocGiaDTO(1, loaiDocGiaText.Text);
            if (LoaiDocGiaBUS.ThemLoaiDocGia(loai))
            {
                list.Add(loai);
                MessageBox.Show("Thêm loại độc giả mới thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void capnhatButton_Click(object sender, RoutedEventArgs e)
        {
            if (loaiDocGiaText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên loại độc giả", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var index = myListView.SelectedIndex;
            if (index != -1)
            {
                if (LoaiDocGiaBUS.CapNhatLoaiDocGia(list[index].MaLoai, loaiDocGiaText.Text))
                {
                    list[index].TenLoai = loaiDocGiaText.Text;
                    MessageBox.Show("Cập nhật loại độc giả thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn loại độc giả cần cập nhật", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void xoaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
            var index = myListView.SelectedIndex;
            if (index != -1)
            {
                LoaiDocGiaDTO loai = list[index];
                if (LoaiDocGiaBUS.XoaLoaiDocGia(loai.MaLoai))
                {
                    list.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn loại độc giả cần xóa", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list = new BindingList<LoaiDocGiaDTO>(LoaiDocGiaDAO.LayDanhSachLoaiDocGia());
            myListView.ItemsSource = list;
        }
    }
}
