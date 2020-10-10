using Library;

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLCafe.API.Login
{
    public class UserServices : IUserServices
    {
        //private QLCafeContext _QLCafeContext;
        //public UserServices(QLCafeContext qLCafeContext)
        //{
        //    this._QLCafeContext = qLCafeContext;
        //}
        private string DeCodePassWord(string pwbase64)
        {
            try
            {

                string encode = pwbase64, decode = "";
                int amountSpecialCharacters = Convert.ToInt32(encode.Substring(0, 1));
                int locationAdd = Convert.ToInt32(encode.Substring(encode.Length - 2));
                encode = encode.Substring(1, encode.Length - 3); //xoa dau xoa cuoi
                decode = encode.Remove(locationAdd, amountSpecialCharacters); //bor chuoix racs
                return decode;
            }
            catch 
            {
                return null;
            }
        }
        #region chuyển đổi chữ có dấu thành không giấu
        static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        #endregion
        public async Task<string> Authenticate(LoginRequest request)
        {
            NhanVien s = new NhanVien { MaNhanVien = "NV01", HoTen = "Nguyễn Văn A", GioiTinh = "NAM", QueQuan = "Kiên Giang", NgaySinh = DateTime.Parse("1995-09-01"), NgayVaoLam = DateTime.Parse("2005-09-01"), BoPhanID = 1 };
            var ten = s.HoTen.Split(" ");
            s.TenDangNhap = s.MaNhanVien + convertToUnSign(ten[ten.Length - 1]);
            s.MatKhau = "dABhAG4AZABhAHQAMgA1ADAAMwA=";//tandat2503
            if (DeCodePassWord(request.PassWord) == s.MatKhau ) return "dang nhap thanh cong";
            return null ;
        }
        //private string DangNhap(string user,string pw)
        //{
             
        //    var dbNhanVien = _QLCafeContext.NhanViens;
        //    string sqlcommamd = "Select * from NhanVien Where TenDangNhap = @user and MatKhau = @pw";
        //    var tontai = dbNhanVien.FromSqlRaw(sqlcommamd, new SqlParameter("@user", user),new SqlParameter("@pw",pw));
        //    if(tontai.Count<NhanVien>() >0)
        //    {
        //        return tontai.First().TenDangNhap + "pw"+ tontai.First().MatKhau;
        //    }
        //    return null;
           
        //}

       
    }
}
