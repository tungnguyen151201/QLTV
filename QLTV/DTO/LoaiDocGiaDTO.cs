﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    public class LoaiDocGiaDTO
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public LoaiDocGiaDTO(int maloai, string tenloai)
        {
            MaLoai = maloai;
            TenLoai = tenloai;
        }
    }
}
