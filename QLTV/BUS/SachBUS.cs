using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
