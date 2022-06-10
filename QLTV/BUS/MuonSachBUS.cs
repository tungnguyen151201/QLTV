using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DAO;
using QLTV.DTO;
namespace QLTV.BUS
{
    class MuonSachBUS
    {
        public static List<SachDTO> LoadSachMuon()
        {
            return MuonSachDAO.LoadSach();
        }
        public static List<SachDTO> TraCuuSachMuon(string str)
        {
            return MuonSachDAO.TracuuSach(str);
        }
        public static bool MuonSach(PhieuMuonSachDTO pm)
        {
            return MuonSachDAO.MuonSach(pm);
        }
    }
}
