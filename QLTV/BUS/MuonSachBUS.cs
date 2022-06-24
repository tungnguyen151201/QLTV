using QLTV.DAO;
using QLTV.DTO;
using System.Collections.Generic;
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
