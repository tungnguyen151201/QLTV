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
    }
}
