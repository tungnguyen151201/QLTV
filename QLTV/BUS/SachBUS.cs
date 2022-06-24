using QLTV.DAO;
using QLTV.DTO;

namespace QLTV.BUS
{
    public class SachBUS
    {
        public static bool ThemSach(SachDTO sach)
        {
            return SachDAO.ThemSach(sach);
        }
    }
}
