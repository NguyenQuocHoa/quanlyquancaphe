using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class NhanVien
    {
        public int ID { get; set; }

        [Display(Name = "Mã Nhân Viên")]
        public string MaNhanVien { get; set; }

        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Display(Name = "Tên Đăng Nhập")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Giới Tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Quê Quán")]
        public string QueQuan { get; set; }

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Ngày Vào Làm")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayVaoLam { get; set; }

        [Display(Name = "Bộ Phận ID")]
        public int BoPhanID { get; set; }

        //public BoPhan BoPhan { get; set; }
    }
}
