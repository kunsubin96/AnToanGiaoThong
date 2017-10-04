using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using dataAccessLayer;
using System.Data;

namespace bussinessAccessLayer.DangNhap_DangKi
{
    public class loginBA
    {

        dataAccess da;
        public loginBA()
        {
            da=new dataAccess();
          
        }
        public int checkLogin(string username,string password)
        {
            System.Diagnostics.Debug.Write(username+"  "+password);
            return da.checkUserLogin("spDangNhap", System.Data.CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@username", username),
                new System.Data.SqlClient.SqlParameter("@password", password));
        }
        public DataSet infoUser(string username)
        {
            string sql = string.Format("select * from tblTaiKhoan where Username=N'{0}' ", username);
            return da.executeQueryDataSet(sql);
        }

    }//end class
}
