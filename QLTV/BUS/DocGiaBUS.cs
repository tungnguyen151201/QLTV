using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.BUS
{
    public class DocGiaBUS
    {
        public static bool ThemDocGia(DocGiaDTO docgia)
        {
            if (DocGiaDAO.TimDocGia(docgia.MaDocGia) != null)
            {
                return false;
            }
            return DocGiaDAO.ThemDocGia(docgia);
        }
        
        public static DocGiaDTO TimDocGia(int maDocGia)
        {
            return DocGiaDAO.TimDocGia(maDocGia);
        }

        public static bool CapNhatDocGia(DocGiaDTO docgia)
        {
            return DocGiaDAO.CapNhatDocGia(docgia);
        }
    }
}
