using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
