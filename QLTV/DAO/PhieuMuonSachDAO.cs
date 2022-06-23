using Npgsql;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DAO
{
    class PhieuMuonSachDAO
    {
        public static PhieuMuonSachDTO TimSach(int maSach)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM \"PhieuMuonSach\" WHERE \"MaSach\"=@masach";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("masach", maSach);
            cmd.Prepare();

            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PhieuMuonSachDTO phieuMuonSach = new PhieuMuonSachDTO(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetDateTime(2));
                    return phieuMuonSach;
                }
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return null;
        }
        public static bool ThemPhieuMuonSach(PhieuMuonSachDTO phieuMuonSach)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "INSERT INTO \"PhieuMuonSach\"(\"MaDocGia\", \"MaSach\", \"NgayMuon\")" +
                " VALUES(@madocgia, @masach, @ngaymuon)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", phieuMuonSach.MaDocGia);
            cmd.Parameters.AddWithValue("masach", phieuMuonSach.MaSach);
            cmd.Parameters.AddWithValue("ngaymuon", phieuMuonSach.NgayMuon);
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
