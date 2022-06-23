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
    public class LoaiSachDAO
    {
        public static List<LoaiSachDTO> LayDanhSachLoaiSach()
        {
            List<LoaiSachDTO> list = new List<LoaiSachDTO>();

            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM \"LoaiSach\"";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    LoaiSachDTO loai = new LoaiSachDTO(rdr.GetInt32(0), rdr.GetString(1));
                    list.Add(loai);
                }
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return list;
        }
        public static bool ThemLoaiSach(LoaiSachDTO loaisach)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "INSERT INTO \"LoaiSach\"(\"TenLoai\") VALUES(@tenloai)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tenloai", loaisach.TenLoai);
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
        public static bool CapNhatLoaiSach(int maloai, string tenloaimoi)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "UPDATE \"LoaiSach\" SET \"TenLoai\"=@tenloai WHERE \"MaLoai\"=@maloai";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("maloai", maloai);
            cmd.Parameters.AddWithValue("tenloai", tenloaimoi);
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
        public static bool XoaLoaiSach(int maloai)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "DELETE FROM \"LoaiSach\" WHERE \"MaLoai\"=@maloai";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("maloai", maloai);
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
