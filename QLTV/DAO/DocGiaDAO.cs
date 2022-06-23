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
    public class DocGiaDAO
    {
        public static DocGiaDTO TimDocGia(int maDocGia)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM \"DocGia\" WHERE \"MaDocGia\"=@madocgia";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", maDocGia);
            cmd.Prepare();

            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DocGiaDTO docgia = new DocGiaDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(6), rdr.GetDateTime(3), rdr.GetDateTime(4), rdr.GetInt32(5), rdr.GetDateTime(7));
                    return docgia;
                }
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return null;
        }
        public static bool ThemDocGia(DocGiaDTO docgia)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "INSERT INTO \"DocGia\"(\"MaDocGia\", \"HoTen\", \"DiaChi\", \"NgaySinh\", \"NgayLapThe\", \"LoaiDocGia\", \"Email\", \"NgayHetHan\")" +
                " VALUES(@madocgia, @hoten, @diachi, @ngaysinh, @ngaylapthe, @loaidocgia, @email, @ngayhethan)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", docgia.MaDocGia);
            cmd.Parameters.AddWithValue("hoten", docgia.HoTen);
            cmd.Parameters.AddWithValue("diachi", docgia.DiaChi);
            cmd.Parameters.AddWithValue("ngaysinh", docgia.NgaySinh);
            cmd.Parameters.AddWithValue("ngaylapthe", docgia.NgayLapThe);
            cmd.Parameters.AddWithValue("loaidocgia", docgia.LoaiDocGia);
            cmd.Parameters.AddWithValue("email", docgia.Email);
            cmd.Parameters.AddWithValue("ngayhethan", docgia.NgayHetHan);
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
        public static bool CapNhatDocGia(DocGiaDTO docgia)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "UPDATE \"DocGia\" SET \"HoTen\" =@hoten, " +
                "\"DiaChi\" =@diachi, \"NgaySinh\" =@ngaysinh, \"NgayLapThe\" =@ngaylapthe, " +
                "\"LoaiDocGia\" =@loaidocgia, \"Email\" =@email, \"NgayHetHan\" =@ngayhethan " +
                "WHERE \"MaDocGia\" =@madocgia";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", docgia.MaDocGia);
            cmd.Parameters.AddWithValue("hoten", docgia.HoTen);
            cmd.Parameters.AddWithValue("diachi", docgia.DiaChi);
            cmd.Parameters.AddWithValue("ngaysinh", docgia.NgaySinh);
            cmd.Parameters.AddWithValue("ngaylapthe", docgia.NgayLapThe);
            cmd.Parameters.AddWithValue("loaidocgia", docgia.LoaiDocGia);
            cmd.Parameters.AddWithValue("email", docgia.Email);
            cmd.Parameters.AddWithValue("ngayhethan", docgia.NgayHetHan);
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
        public static bool XoaDocGia(DocGiaDTO docgia)
        {
            //Delete SQL
            return false;
        }
        public static bool SuaDocGia(DocGiaDTO docgia)
        {
            //Update SQL
            return false;
        }
    }
}
