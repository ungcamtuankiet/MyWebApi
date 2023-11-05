﻿using System;

namespace MyWebAppApi.Data
{
    public class DonHangChiTiet
    {

        public Guid MaHangHoa { get; set; }

        public Guid MaDonHang {  get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        //Relationship
        public DonHang DonHang { get; set; }

        public HangHoa HangHoa { get; set; }
    }
}
