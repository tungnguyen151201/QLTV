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

            string sql = "SELECT * FROM docgia WHERE madocgia=@madocgia";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", maDocGia);
            cmd.Prepare();

            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DocGiaDTO docgia = new DocGiaDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(6), rdr.GetDateTime(3), rdr.GetDateTime(4), rdr.GetInt32(5));
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

            string sql = "INSERT INTO docgia(madocgia, hoten, diachi, ngaysinh, ngaylapthe, loaidocgia, email)" +
                " VALUES(@madocgia, @hoten, @diachi, @ngaysinh, @ngaylapthe, @loaidocgia, @email)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("madocgia", docgia.MaDocGia);
            cmd.Parameters.AddWithValue("hoten", docgia.HoTen);
            cmd.Parameters.AddWithValue("diachi", docgia.DiaChi);
            cmd.Parameters.AddWithValue("ngaysinh", docgia.NgaySinh);
            cmd.Parameters.AddWithValue("ngaylapthe", docgia.NgayLapThe);
            cmd.Parameters.AddWithValue("loaidocgia", docgia.LoaiDocGia);
            cmd.Parameters.AddWithValue("email", docgia.Email);
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
