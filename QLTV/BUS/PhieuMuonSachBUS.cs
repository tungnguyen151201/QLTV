using QLTV.DAO;
using QLTV.DTO;

namespace QLTV.BUS
{
    class PhieuMuonSachBUS
    {
        public static bool ThemPhieuMuonSach(PhieuMuonSachDTO phieuMuonSach)
        {
            if (PhieuMuonSachDAO.TimSach(phieuMuonSach.MaSach) != null)
            {
                return false;
            }
            return PhieuMuonSachDAO.ThemPhieuMuonSach(phieuMuonSach);
        }
        public static PhieuMuonSachDTO TimSach(int maSach)
        {
            return PhieuMuonSachDAO.TimSach(maSach);
        }
    }
}
