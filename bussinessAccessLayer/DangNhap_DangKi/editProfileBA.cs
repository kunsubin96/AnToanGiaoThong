using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using dataAccessLayer;
namespace bussinessAccessLayer.DangNhap_DangKi
{
    public class editProfileBA
    {
        dataAccess da;
        public editProfileBA()
        {
            da=new dataAccess();

        }
        public bool editProfile(string userName, string hoten, string quequan, DateTime
            ngaysinh)
        {
            return da.executeNonQuery("spCapNhatProfile", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@username", userName),
                new System.Data.SqlClient.SqlParameter("@hoten", hoten),
                new System.Data.SqlClient.SqlParameter("@quequan", quequan),
                new System.Data.SqlClient.SqlParameter("@ngaysinh", ngaysinh));
        }
        public bool editAvatar(string userName,byte[] avatar)
        {
            return da.executeNonQuery("spCapNhatAvatar", CommandType.StoredProcedure,
               new System.Data.SqlClient.SqlParameter("@username", userName),
               new System.Data.SqlClient.SqlParameter("@avatar", avatar));
        }

        public bool changePassword(string userName,string oldPassword,string newPassword)
        {
            return da.executeNonQuery("spDoiMatKhau", CommandType.StoredProcedure,
              new System.Data.SqlClient.SqlParameter("@username", userName),
              new System.Data.SqlClient.SqlParameter("@oldpassword", oldPassword),
              new System.Data.SqlClient.SqlParameter("@newpassword", newPassword));
        }
    }//end class
}
