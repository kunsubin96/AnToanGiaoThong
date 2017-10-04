using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dataAccessLayer;
namespace bussinessAccessLayer.DangNhap_DangKi
{
  
    public class registerBA
    {
        dataAccess da;
        public registerBA()
        {
            da=new dataAccess();
        }
        public bool register(string userName,string password)
        {
            return da.executeNonQuery("spDangKi", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@username", userName),
                new System.Data.SqlClient.SqlParameter("@password", password));
        }
      
    }//end class
}
