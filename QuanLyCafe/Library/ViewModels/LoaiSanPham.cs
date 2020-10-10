using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class LoaiSanPham
    {
        public int ID { get; set; }

        [Display(Name = "Mã Loại Sản Phẩm")]
        public string MaLoaiSanPham { get; set; }

        [Display(Name = "Tên Loại sản phẩm")]
        public string TenLoaiSanPham { get; set; }
    }
}
