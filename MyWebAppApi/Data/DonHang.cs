using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWebAppApi.Data
{
    public class DonHang
    {
        public enum TinhTrangDonDatHang
        {
            New = 0, Payment = 1, Complete = 2, Cancel = -1
        }
        public Guid MaDonHang { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime NgayGiao { get; set; }

        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }

        public string NguoiNhanHang { get; set; }

        public string DiaChiGiao { get; set; }

        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
