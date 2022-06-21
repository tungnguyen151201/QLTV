using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    public class QuyDinhDTO
    {
        public int TuoiToiThieu { get; set; }
        public int TuoiToiDa { get; set; }
        public int ThoiHanGiaTriThe { get; set; }
        public int KhoangCachNamXuatBan { get; set; }
        public int SoSachMuonToiDa { get; set; }
        public int SoNgayMuonToiDa { get; set; }
        public QuyDinhDTO()
        {
            TuoiToiThieu = 18;
            TuoiToiDa = 35;
            ThoiHanGiaTriThe = 1;
            KhoangCachNamXuatBan = 10;
            SoSachMuonToiDa = 5;
            SoNgayMuonToiDa = 7;
        }    
        public QuyDinhDTO(int tuoitoithieu, int tuoitoida, int thoihangiatrithe, int khoangcachnxb, int sosachmuontoida, int songaymuontoida)
        {
            TuoiToiThieu = tuoitoithieu;
            TuoiToiDa = tuoitoida;
            ThoiHanGiaTriThe = thoihangiatrithe;
            KhoangCachNamXuatBan = khoangcachnxb;
            SoSachMuonToiDa = sosachmuontoida;
            SoNgayMuonToiDa = songaymuontoida;
        }
    }
}
