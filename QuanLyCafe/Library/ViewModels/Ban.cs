using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Ban
    {
        public int ID { get; set; }

        [Display(Name = "Mã Bàn")]
        public string MaBan { get; set; }

        [Display(Name = "Sức Chứa")]
        public int SucChua { get; set; }

        [Display(Name = "Tình Trạng")]
        public string TinhTrang { get; set; }
    }
}
