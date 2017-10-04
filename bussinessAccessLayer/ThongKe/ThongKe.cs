using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data;
namespace bussinessAccessLayer.ThongKe
{
    public class ThongKe
    {
        dataAccess da;
        public ThongKe()
        {
            da = new dataAccess();
        }
        public DataSet getAllLanThiUser(string user)
        {
            string sql = string.Format("select MaLanThi, Diem from tblThiTracNghiem where UserName='{0}'",user);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getDiemMAX_DiemTB(string user)
        {
            string sql = string.Format("select DiemCaoNhat, DiemTrungBinh from tblThongKe where UserName='{0}'", user);
            return da.executeQueryDataSet(sql);
        }
    }
}
