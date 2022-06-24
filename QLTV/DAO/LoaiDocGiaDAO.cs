using Npgsql;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QLTV.DAO
{
    public class LoaiDocGiaDAO
    {
        public static List<LoaiDocGiaDTO> LayDanhSachLoaiDocGia()
        {
            List<LoaiDocGiaDTO> list = new List<LoaiDocGiaDTO>();

            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM \"LoaiDocGia\"";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    LoaiDocGiaDTO loai = new LoaiDocGiaDTO(rdr.GetInt32(0), rdr.GetString(1));
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
        public static bool ThemLoaiDocGia(LoaiDocGiaDTO loaidocgia)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "INSERT INTO \"LoaiDocGia\"(\"TenLoai\") VALUES(@tenloai)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tenloai", loaidocgia.TenLoai);
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
        public static bool CapNhatLoaiDocGia(int maloai, string tenloaimoi)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "UPDATE \"LoaiDocGia\" SET \"TenLoai\"=@tenloai WHERE \"MaLoai\"=@maloai";
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
        public static bool XoaLoaiDocGia(int maloai)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "DELETE FROM \"LoaiDocGia\" WHERE \"MaLoai\"=@maloai";
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
