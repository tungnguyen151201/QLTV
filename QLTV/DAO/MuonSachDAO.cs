using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DTO;
using Npgsql;
using System.Data;
using System.Diagnostics;
namespace QLTV.DAO
{

    class MuonSachDAO
    {
        private static List<SachDTO> List_Sach = new List<SachDTO>();

        public static SachDTO parseDataTable(Object []row)
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
        static MuonSachDAO()
        {
            var sql = "SELECT * FROM public.\"Sach\"";

            DataTable Sach = ConnectingDatabase.getDataset(sql);

            for (int i = 0; i < Sach.Rows.Count; i++)
            {
                Object[] row = Sach.Rows[i].ItemArray;
                List_Sach.Add(parseDataTable(row));
            }

        }
        public static List<SachDTO>  LoadSach()
        {
            return List_Sach;
        }
        public static List<SachDTO> TracuuSach(string Name)
        {
            List<SachDTO> List_Tra_Cuu = new List<SachDTO>();

            var sql = $"SELECT * FROM public.\"Sach\" WHERE \"TenSach\" LIKE \'{Name}%\'";
            DataTable Sach_tra_cuu = ConnectingDatabase.getDataset(sql );
            for (int i = 0; i < Sach_tra_cuu.Rows.Count; i++)
            {
                Object[] row = Sach_tra_cuu.Rows[i].ItemArray;
                List_Tra_Cuu.Add(parseDataTable(row));
            }
            return List_Tra_Cuu;
        }
     
        public static bool MuonSach(PhieuMuonSachDTO pm)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "INSERT INTO \"PhieuMuonSach\"(\"MaDocGia\", \"MaSach\", \"NgayMuon\")" +
                " VALUES(@madocgia, @masach, @ngaymuon)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", pm.MaDocGia);
            cmd.Parameters.AddWithValue("masach", pm.MaSach);
            cmd.Parameters.AddWithValue("ngaymuon", pm.NgayMuon);
            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
      
    }
}
