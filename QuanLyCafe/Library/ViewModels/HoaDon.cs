using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class HoaDon
    {
        public int ID { get; set; }

        [Display(Name = "Mã Hóa Đơn")]
        public string MaHoaDon { get; set; }

        [Display(Name = "Tổng Tiền")]
        public Decimal TongTien { get; set; }

        [Display(Name = "Ngày Tạo")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayTao { get; set; }

        [Display(Name = "Đã Thanh Toán")]
        public bool DaThanhToan { get; set; }

        [Display(Name = "Nhân Viên ID")]
        public int NhanVienID { get; set; }

        [Display(Name = "Bàn ID")]
        public int BanID { get; set; }
    }
}
