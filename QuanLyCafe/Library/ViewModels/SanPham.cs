using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class SanPham
    {
        public int ID { get; set; }

        [Display(Name = "Mã Sản Phẩm")]
        public string MaSanPham { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Giá Bán")]
        public double GiaBan { get; set; }

        [Display(Name = "Tình Trạng")]
        public string TinhTrang { get; set; }

        [Display(Name = "Loại Sản Phẩm ID")]
        public int LoaiSanPhamID { get; set; }

        //public LoaiSanPham LoaiSanPham { get; set; }
    }
}
