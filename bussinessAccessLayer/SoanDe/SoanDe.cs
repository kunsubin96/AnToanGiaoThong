using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data;
namespace bussinessAccessLayer.SoanDe
{
    public class SoanDe
    {
        dataAccess da;
        public SoanDe()
        {
            da = new dataAccess();
        }
        public DataSet getMAXCau()
        {
            string sql = string.Format("select MAX(MaCauHoi) from tblNganHangCauHoi");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getTongCau()
        {
            string sql = string.Format("select COUNT(*) from tblNganHangCauHoi");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getDapAnCau(string macau)
        {
            string sql = string.Format("select [dbo].[F_LayDapAnCauHoi]({0})", macau);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getChiTietCauHoi(int macau)
        {
            string sql = string.Format("select * from tblNganHangCauHoi where MaCauHoi={0}", macau);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getTatCaMaCauHoi()
        {
            string sql = string.Format("select MaCauHoi from tblNganHangCauHoi");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getAllCauHoi()
        {
            return da.executeQueryDataSet("select * from tblNganHangCauHoi");
        }
    }
}
