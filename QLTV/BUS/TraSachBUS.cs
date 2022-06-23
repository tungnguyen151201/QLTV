using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DAO;
using QLTV.DTO;
namespace QLTV.BUS
{
    class TraSachBUS
    {
        public static List<SachDTO> LoadSach(int manguoidung)
        {
            return TraSachDAO.LoadSachMuon(manguoidung);
        }
        public static List<SachDTO> TraCuuSach(string str)
        {
            return TraSachDAO.TracuuSachMuon(str);
        }
        public static  bool TraSach(int Id_sach)
        {
            return TraSachDAO.TraSach(Id_sach);
        }

    }
}
