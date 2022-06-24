using QLTV.DAO;
using QLTV.DTO;

namespace QLTV.BUS
{
    public class QuyDinhBUS
    {
        public static int TuoiToiThieu()
        {
            QuyDinhDTO quydinh = QuyDinhDAO.LayQuyDinh();
            return quydinh.TuoiToiThieu;
        }
        public static int TuoiToiDa()
        {
            QuyDinhDTO quydinh = QuyDinhDAO.LayQuyDinh();
            return quydinh.TuoiToiDa;
        }
        public static int ThoiHanGiaTriThe()
        {
            QuyDinhDTO quydinh = QuyDinhDAO.LayQuyDinh();
            return quydinh.ThoiHanGiaTriThe;
        }
        public static int KhoangCachNamXuatBan()
        {
            QuyDinhDTO quydinh = QuyDinhDAO.LayQuyDinh();
            return quydinh.KhoangCachNamXuatBan;
        }
        public static int SoSachMuonToiDa()
        {
            QuyDinhDTO quydinh = QuyDinhDAO.LayQuyDinh();
            return quydinh.SoSachMuonToiDa;
        }
        public static int SoNgayMuonToiDa()
        {
            QuyDinhDTO quydinh = QuyDinhDAO.LayQuyDinh();
            return quydinh.SoNgayMuonToiDa;
        }
        public static bool ThayDoiQuyDinh(QuyDinhDTO quydinh)
        {
            return QuyDinhDAO.ThayDoiQuyDinh(quydinh);
        }
    }
}
