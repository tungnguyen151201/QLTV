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
    public class NguoiDungDAO
    {
        public static NguoiDungDTO TimNguoiDung(string tenDangNhap)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM nguoidung WHERE tendangnhap=@tendangnhap";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tendangnhap", tenDangNhap);
            cmd.Prepare();

            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NguoiDungDTO nguoidung = new NguoiDungDTO(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3), rdr.GetInt32(4));
                    return nguoidung;
                }
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return null;
        }
        public static bool ThemNguoiDung(NguoiDungDTO nguoidung)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "INSERT INTO nguoidung(tendangnhap, matkhau, ngaytao, loainguoidung)" +
                " VALUES(@tendangnhap, @matkhau, @ngaytao, @loainguoidung)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tendangnhap", nguoidung.TenDangNhap);
            cmd.Parameters.AddWithValue("matkhau", nguoidung.MatKhau);
            cmd.Parameters.AddWithValue("ngaytao", nguoidung.NgayTao);
            cmd.Parameters.AddWithValue("loainguoidung", nguoidung.LoaiNguoiDung);
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
