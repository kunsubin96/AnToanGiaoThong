using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace bussinessAccessLayer.Admin
{
    public class TaiKhoan
    {
        dataAccess da;
        public TaiKhoan()
        {
            da = new dataAccess();
        }
        public DataSet getAllUser()
        {
            string sql = string.Format("select UserName, HoTen, QueQuan, NgaySinh, Avatar from tblTaiKhoan where UserName!=N'ADMIN'");
            return da.executeQueryDataSet(sql);
        }
        public bool XoaTaiKhoan(string username)
        {
            return da.executeNonQuery("spXoaTaiKhoan", CommandType.StoredProcedure,
                new SqlParameter("@UserName", username));
        }
        public bool ThemTaiKhoan(string username,string pass, string hoten, string quequan, DateTime ngaysinh, byte[] avatar)
        {
            return da.executeNonQuery("spThemTaiKhoan", CommandType.StoredProcedure,
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", pass),
                new SqlParameter("@HoTen", hoten),
                new SqlParameter("@QueQuan", quequan),
                new SqlParameter("@NgaySinh", ngaysinh),
                new SqlParameter("@Avatar", avatar));
        }
        public bool CapNhatTaiKhoan(string username, string hoten, string quequan, DateTime ngaysinh, byte[] avatar)
        {
            return da.executeNonQuery("spCapNhatTaiKhoan", CommandType.StoredProcedure,
                new SqlParameter("@UserName", username),
                new SqlParameter("@HoTen", hoten),
                new SqlParameter("@QueQuan", quequan),
                new SqlParameter("@NgaySinh", ngaysinh),
                new SqlParameter("@Avatar", avatar));
        }
    }
}
