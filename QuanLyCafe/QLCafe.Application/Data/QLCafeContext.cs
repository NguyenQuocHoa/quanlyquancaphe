using Microsoft.EntityFrameworkCore;
using QLCafe.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.Application.Data
{
    public class QLCafeContext : DbContext
    {
        public QLCafeContext(DbContextOptions<QLCafeContext> options)
            : base(options)
        {
        }

        public DbSet<Ban> Bans { get; set; }
        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<ChiTietHoaDon> chiTietHoaDons { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
    }
}
