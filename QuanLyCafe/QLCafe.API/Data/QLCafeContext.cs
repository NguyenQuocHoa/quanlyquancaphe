using Library;
using Microsoft.EntityFrameworkCore;


namespace QLCafe.API.Data

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
        public DbSet<SanPham> SanPhams { get; set; }
    }
}
