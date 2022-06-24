using QLTV.BUS;
using QLTV.DAO;
using QLTV.DTO;
using System.Windows;

namespace QLTV.GUI
{
    /// <summary>
    /// Interaction logic for DocGiaGUI.xaml
    /// </summary>
    public partial class TraCuuSachMuonGUI : Window
    {
        public TraCuuSachMuonGUI()
        {
            InitializeComponent();
        }


        private void SachMuonSearch_Btn_Click(object sender, RoutedEventArgs e)
        {
            /*string str_search = tbxTraCuu.Text;

            List<SachDTO> list_searched = TraSachBUS.TraCuuSach(str_search);
            if (list_searched?.Any() != true)
            {
                MessageBox.Show("Không tìm thấy sách!");
            }
            else
            {
                list_Book_Rental.ItemsSource = list_searched;

            }*/
            NguoiDungDTO nguoidung = NguoiDungBUS.TimNguoiDung(tbxTraCuu.Text);
            list_Book_Rental.ItemsSource = TraSachBUS.LoadSach(nguoidung.MaNguoiDung);
        }
        private void traSachButton_Click(object sender, RoutedEventArgs e)
        {

            var button = (FrameworkElement)sender;
            var tag = button.Tag;
            int masach = int.Parse(tag.ToString());

            bool traSach = TraSachDAO.TraSach(masach);
            if (traSach)
            {

                MessageBox.Show("Trả sách thành công!");
                //list_Book_Rental.ItemsSource = null;
                //list_Book_Rental.Items.Clear();
                ////// The list<> has been updated so reload the listview [2]
                //NguoiDungDTO nguoidung = NguoiDungBUS.TimNguoiDung(tbxTraCuu.Text);
                //list_Book_Rental.ItemsSource = TraSachBUS.LoadSach(nguoidung.MaNguoiDung);
                //list_Book_Rental.Items.Refresh();


            }
            else
            {
                MessageBox.Show("Lỗi!");
            }


        }

    }
}
