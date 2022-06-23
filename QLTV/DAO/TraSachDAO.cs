using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLTV.DTO;
namespace QLTV.DAO
{
    class TraSachDAO
    {
        private static List<SachDTO> List_Sach_Muon = new List<SachDTO>();

        public static SachDTO parseDataTable(Object[] row)
        {
            SachDTO line;
            string masach = row[0].ToString();
            string tensach = row[1].ToString();
            string theloai = row[2].ToString();
            string tacgia = row[3].ToString();
            string namXB = row[4].ToString();
            string NXB = row[5].ToString();
            string ngaynhap = row[6].ToString();
            line = new SachDTO(masach, tensach, theloai, tacgia, namXB, NXB, ngaynhap);
            return line;
        }
        public static List<SachDTO> LoadSachMuon(int manguoidung)
        {
            var sql = "SELECT * FROM public.\"Sach\" S, \"PhieuMuonSach\" PM WHERE S.\"MaSach\" = PM.\"MaSach\"" +
                $"AND PM.\"MaDocGia\"={manguoidung}";

            DataTable Sach = ConnectingDatabase.getDataset(sql);

            for (int i = 0; i < Sach.Rows.Count; i++)
            {
                Object[] row = Sach.Rows[i].ItemArray;
                List_Sach_Muon.Add(parseDataTable(row));
            }
            return List_Sach_Muon;            
        }
        public static List<SachDTO> TracuuSachMuon(string str)
        {
            List<SachDTO> List_Tra_Cuu = new List<SachDTO>();
            var sql = $"SELECT * FROM public.\"Sach\" S, \"PhieuMuonSach\" PM WHERE S.\"MaSach\" = PM.\"MaSach\" AND  S.\"TenSach\" LIKE \'{str}%\'";
         
            DataTable Sach_tra_cuu = ConnectingDatabase.getDataset(sql);
            for (int i = 0; i < Sach_tra_cuu.Rows.Count; i++)
            {
                Object[] row = Sach_tra_cuu.Rows[i].ItemArray;
                List_Tra_Cuu.Add(parseDataTable(row));
            }
            return List_Tra_Cuu;
        }

        public static bool TraSach(int masach)
        {
            //Insert SQL
            var Sql = $"DELETE FROM public.\"PhieuMuonSach\" WHERE \"MaSach\"={masach}";
            bool delete = ConnectingDatabase.NewQuery(Sql);
            if (delete)

                return true;
            else
                return false;
        }

    }
}
