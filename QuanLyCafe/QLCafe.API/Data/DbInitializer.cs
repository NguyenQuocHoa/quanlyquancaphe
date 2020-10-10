
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Library;

namespace QLCafe.API.Data
{
    public static class DbInitializer
    {
        #region chuyển đổi chữ có dấu thành không giấu
        static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        #endregion
        public static void Initialize(QLCafeContext context)
        {

            context.Database.EnsureCreated();

            // Look for any NhanViens.
            if (context.NhanViens.Any())
            {
                return;   // DB has been seeded
            }

            var boPhans = new BoPhan[]
            {
                new BoPhan{MaBoPhan="LT",TenBoPhan="Lễ Tân"},
                new BoPhan{MaBoPhan="TV",TenBoPhan="Tạp Vụ"},
                new BoPhan{MaBoPhan="PV",TenBoPhan="Phục Vụ"},
                new BoPhan{MaBoPhan="PC",TenBoPhan="Pha Chế"},
            };
            foreach (BoPhan c in boPhans)
            {
                context.BoPhans.Add(c);
            }
            context.SaveChanges();

            var nhanViens = new NhanVien[]
            {
                new NhanVien{MaNhanVien="NV01",HoTen="Nguyễn Văn A",GioiTinh="NAM",QueQuan="Kiên Giang",NgaySinh=DateTime.Parse("1995-09-01"), NgayVaoLam=DateTime.Parse("2005-09-01"), BoPhanID=1},
                new NhanVien{MaNhanVien="NV02",HoTen="Nguyễn Văn B",GioiTinh="NAM",QueQuan="Tiền Giang",NgaySinh=DateTime.Parse("1994-03-01"), NgayVaoLam=DateTime.Parse("2004-09-01"), BoPhanID=1},
                new NhanVien{MaNhanVien="NV03",HoTen="Nguyễn Á Bằng",GioiTinh="NAM",QueQuan="Hậu Giang",NgaySinh=DateTime.Parse("1993-03-01"), NgayVaoLam=DateTime.Parse("2004-09-01"), BoPhanID=2},
                new NhanVien{MaNhanVien="NV04",HoTen="Lê Đức Thọ",GioiTinh="NAM",QueQuan="An Giang",NgaySinh=DateTime.Parse("1992-02-01"), NgayVaoLam=DateTime.Parse("2005-09-01"), BoPhanID=2},
                new NhanVien{MaNhanVien="NV05",HoTen="Hoàng Xuân Thao",GioiTinh="NAM",QueQuan="Hà Giang",NgaySinh=DateTime.Parse("1991-02-01"), NgayVaoLam=DateTime.Parse("2005-09-01"), BoPhanID=2},
                new NhanVien{MaNhanVien="NV06",HoTen="Nguyễn Thị Hoa",GioiTinh="NỮ",QueQuan="Bình Dương",NgaySinh=DateTime.Parse("1991-05-01"), NgayVaoLam=DateTime.Parse("2005-09-01"), BoPhanID=3},
                new NhanVien{MaNhanVien="NV07",HoTen="Lê Thị Thắm",GioiTinh="NỮ",QueQuan="Bình Phước",NgaySinh=DateTime.Parse("1991-06-01"), NgayVaoLam=DateTime.Parse("2005-09-01"), BoPhanID=3},
                new NhanVien{MaNhanVien="NV08",HoTen="Vũ Thị Liên",GioiTinh="NỮ",QueQuan="Tây Ninh",NgaySinh=DateTime.Parse("1992-07-01"), NgayVaoLam=DateTime.Parse("2004-09-01"), BoPhanID=3},
                new NhanVien{MaNhanVien="NV09",HoTen="Lâm Thị Hiền",GioiTinh="NỮ",QueQuan="Bình Dương",NgaySinh=DateTime.Parse("1992-08-01"), NgayVaoLam=DateTime.Parse("2004-09-01"), BoPhanID=4},
                new NhanVien{MaNhanVien="NV10",HoTen="Hoàng Hằng",GioiTinh="NỮ",QueQuan="Kiên Giang",NgaySinh=DateTime.Parse("1992-09-01"), NgayVaoLam=DateTime.Parse("2006-09-01"), BoPhanID=4},

            };

            foreach (NhanVien s in nhanViens)
            {
                var ten = s.HoTen.Split(" ");
                UTF8Encoding encoding = new UTF8Encoding();
                s.TenDangNhap = s.MaNhanVien+convertToUnSign(ten[ten.Length-1]);
                s.MatKhau = new SHA256Managed().ComputeHash(encoding.GetBytes(s.TenDangNhap + "dev123321")).ToString();
                context.NhanViens.Add(s);
            }
            context.SaveChanges();

            var bans = new Ban[]
            {
            new Ban{MaBan="B001", SucChua=6, TinhTrang="TRỐNG"},
            new Ban{MaBan="B002", SucChua=7, TinhTrang="TRỐNG"},
            new Ban{MaBan="B003", SucChua=5, TinhTrang="TRỐNG"},
            new Ban{MaBan="B004", SucChua=6, TinhTrang="TRỐNG"},
            new Ban{MaBan="B005", SucChua=8, TinhTrang="TRỐNG"},
            new Ban{MaBan="B006", SucChua=9, TinhTrang="TRỐNG"},
            new Ban{MaBan="B007", SucChua=10, TinhTrang="TRỐNG"},
            new Ban{MaBan="B008", SucChua=4, TinhTrang="TRỐNG"},
            new Ban{MaBan="B009", SucChua=5, TinhTrang="TRỐNG"},
            new Ban{MaBan="B010", SucChua=6, TinhTrang="TRỐNG"},
            };
            foreach (Ban b in bans)
            {
                context.Bans.Add(b);
            }
            context.SaveChanges();


            var loaiSanPhams = new LoaiSanPham[]
            {
                 new LoaiSanPham{MaLoaiSanPham="LSP01", TenLoaiSanPham="Đồ uống có đá"},
                 new LoaiSanPham{MaLoaiSanPham="LSP02", TenLoaiSanPham="Đồ uống không đá"},
                 new LoaiSanPham{MaLoaiSanPham="LSP03", TenLoaiSanPham="Đồ ăn thường"},
                 new LoaiSanPham{MaLoaiSanPham="LSP04", TenLoaiSanPham="Đồ ăn chay"}
            };
            foreach (LoaiSanPham s in loaiSanPhams)
            {
                context.LoaiSanPhams.Add(s);
            }
            context.SaveChanges();


            var sanPhams = new SanPham[]
            {
                new SanPham{MaSanPham="CPD", TenSanPham="Cà phê đen", GiaBan=13000, TinhTrang="", LoaiSanPhamID=1},
                new SanPham{MaSanPham="CPS", TenSanPham="Cà phê sữa", GiaBan=16000, TinhTrang="", LoaiSanPhamID=1},
                new SanPham{MaSanPham="CPDN", TenSanPham="Cà phê đen nóng", GiaBan=13000, TinhTrang="", LoaiSanPhamID=2},
                new SanPham{MaSanPham="CPSN", TenSanPham="Cà phê sữa nóng", GiaBan=13000, TinhTrang="", LoaiSanPhamID=2},
                new SanPham{MaSanPham="NCH", TenSanPham="Nước chanh", GiaBan=15000, TinhTrang="", LoaiSanPhamID=1},
                new SanPham{MaSanPham="NCA", TenSanPham="Nước Cam", GiaBan=20000, TinhTrang="", LoaiSanPhamID=1},
                new SanPham{MaSanPham="CS", TenSanPham="Cơm sườn", GiaBan=23000, TinhTrang="", LoaiSanPhamID=3},
                new SanPham{MaSanPham="BU", TenSanPham="Bún", GiaBan=23000, TinhTrang="", LoaiSanPhamID=3},
                new SanPham{MaSanPham="HU", TenSanPham="Hủ tiếu", GiaBan=23000, TinhTrang="", LoaiSanPhamID=3},
                new SanPham{MaSanPham="MI", TenSanPham="Mì gói", GiaBan=15000, TinhTrang="", LoaiSanPhamID=3},
                new SanPham{MaSanPham="MC", TenSanPham="Mì chay", GiaBan=15000, TinhTrang="", LoaiSanPhamID=4},
                new SanPham{MaSanPham="CC", TenSanPham="Cơm chay", GiaBan=15000, TinhTrang="", LoaiSanPhamID=4},
            };
            foreach (SanPham s in sanPhams)
            {
                context.SanPhams.Add(s);
            }
            context.SaveChanges();
        }
    }
}
