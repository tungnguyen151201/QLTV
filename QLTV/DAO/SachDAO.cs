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
    public class SachDAO
    {
        public static bool ThemSach(SachDTO sach)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "INSERT INTO \"Sach\"(\"TenSach\", \"TheLoai\", \"TacGia\", \"NamXuatBan\", \"NhaXuatBan\", \"NgayNhap\")" +
                " VALUES(@tensach, @theloai, @tacgia, @namxuatban, @nhaxuatban, @ngaynhap)";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tensach", sach.TenSach);
            cmd.Parameters.AddWithValue("theloai", int.Parse(sach.TheLoai));
            cmd.Parameters.AddWithValue("tacgia", sach.TacGia);
            cmd.Parameters.AddWithValue("namxuatban", sach.NamXuatBan);
            cmd.Parameters.AddWithValue("nhaxuatban", sach.NhaXuatBan);
            cmd.Parameters.AddWithValue("ngaynhap", DateTime.Parse(sach.NgayNhap));
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
