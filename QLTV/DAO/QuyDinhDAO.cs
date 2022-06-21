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
    public class QuyDinhDAO
    {
        public static QuyDinhDTO LayQuyDinh()
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM \"QuyDinh\"";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    QuyDinhDTO quydinh = new QuyDinhDTO(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3), rdr.GetInt32(4), rdr.GetInt32(5));
                    return quydinh;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new QuyDinhDTO();
            }
            return new QuyDinhDTO();
        }
        public static bool ThayDoiQuyDinh(QuyDinhDTO quydinh)
        {
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();
            string sql = "DELETE FROM \"QuyDinh\"";
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            sql = "INSERT INTO \"QuyDinh\"(\"TuoiToiThieu\", \"TuoiToiDa\", \"ThoiHanGiaTriThe\", \"KhoangCachNamXuatBan\", \"SoSachMuonToiDa\", \"SoNgayMuonToiDa\")" +
                " VALUES(@tuoitoithieu, @tuoitoida, @thoihangiatrithe, @khoangcachnamxuatban, @sosachmuontoida, @songaymuontoida)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("tuoitoithieu", quydinh.TuoiToiThieu);
            cmd.Parameters.AddWithValue("tuoitoida", quydinh.TuoiToiDa);
            cmd.Parameters.AddWithValue("thoihangiatrithe", quydinh.ThoiHanGiaTriThe);
            cmd.Parameters.AddWithValue("khoangcachnamxuatban", quydinh.KhoangCachNamXuatBan);
            cmd.Parameters.AddWithValue("sosachmuontoida", quydinh.SoSachMuonToiDa);
            cmd.Parameters.AddWithValue("songaymuontoida", quydinh.SoNgayMuonToiDa);
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
