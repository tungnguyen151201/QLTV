using System;

namespace QLTV.DTO
{
    class PhieuMuonSachDTO
    {
        public int MaDocGia { get; set; }
        public int MaSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public PhieuMuonSachDTO(int madocgia, int masach, DateTime ngaymuon)
        {
            MaDocGia = madocgia;
            MaSach = masach;
            NgayMuon = ngaymuon;
        }
    }

}
