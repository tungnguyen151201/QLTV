using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class PhieuMuonSachDTO
    {
        public int MaDocGia{ get; set; }
        public int MaSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public PhieuMuonSachDTO(int madocgia,int masach,DateTime ngaymuon)
        {
            MaDocGia = madocgia;
            MaSach = masach;
            NgayMuon = ngaymuon;
        }
    }
    
}
