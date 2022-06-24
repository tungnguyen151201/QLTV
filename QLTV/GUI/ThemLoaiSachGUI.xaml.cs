using QLTV.BUS;
using QLTV.DAO;
using QLTV.DTO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for ThemLoaiSach.xaml
    /// </summary>
    public partial class ThemLoaiSach : Window
    {
        BindingList<LoaiSachDTO> list;
        public ThemLoaiSach()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list = new BindingList<LoaiSachDTO>(LoaiSachDAO.LayDanhSachLoaiSach());
            myListView.ItemsSource = list;
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var index = myListView.SelectedIndex;
            loaiSachText.Text = list[index].TenLoai;
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
            var index = myListView.SelectedIndex;
            if (index != -1)
            {
                LoaiSachDTO loai = list[index];
                if (LoaiSachBUS.XoaLoaiSach(loai.MaLoai))
                {
                    list.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn loại sách cần xóa", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void themButton_Click(object sender, RoutedEventArgs e)
        {
            if (loaiSachText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên loại sách", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoaiSachDTO loai = new LoaiSachDTO(1, loaiSachText.Text);
            if (LoaiSachBUS.ThemLoaiSach(loai))
            {
                list.Add(loai);
                MessageBox.Show("Thêm loại sách mới thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void capnhatButton_Click(object sender, RoutedEventArgs e)
        {
            if (loaiSachText.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên loại sách", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var index = myListView.SelectedIndex;
            if (index != -1)
            {
                if (LoaiSachBUS.CapNhatLoaiSach(list[index].MaLoai, loaiSachText.Text))
                {
                    list[index].TenLoai = loaiSachText.Text;
                    MessageBox.Show("Cập nhật loại sách thành công", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn loại sách cần cập nhật", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void xoaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
            var index = myListView.SelectedIndex;
            if (index != -1)
            {
                LoaiSachDTO loai = list[index];
                if (LoaiSachBUS.XoaLoaiSach(loai.MaLoai))
                {
                    list.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("Bạn chưa chọn loại sách cần xóa", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
