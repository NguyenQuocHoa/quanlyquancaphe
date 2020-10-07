using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.Application.Models
{
    public class BoPhan
    {
        public int ID { get; set; }

        [Display(Name = "Mã Bộ Phận")]
        public string MaBoPhan { get; set; }

        [Display(Name = "Tên Bộ Phận")]
        public string TenBoPhan { get; set; }

        //public ICollection<NhanVien> NhanViens { get; set; }
    }
}
