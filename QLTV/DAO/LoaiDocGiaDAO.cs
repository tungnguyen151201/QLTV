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
    public class LoaiDocGiaDAO
    {
        public static List<LoaiDocGiaDTO> LayDanhSachLoaiDocGia()
        {
            List<LoaiDocGiaDTO> list = new List<LoaiDocGiaDTO>();
            
            using NpgsqlConnection con = new NpgsqlConnection(DbConfig.Config());
            con.Open();

            string sql = "SELECT * FROM loaidocgia";
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
    }
}
