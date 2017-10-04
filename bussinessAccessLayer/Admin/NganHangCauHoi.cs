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
    public class NganHangCauHoi
    {

        dataAccess da;
        public NganHangCauHoi()
        {
            da = new dataAccess();
        }
        public DataSet getNganHangCauHoi()
        {
            string sql = string.Format("select * from tblNganHangCauHoi");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getCauHoiTheoMa(int macau)
        {
            string sql = string.Format("select * from tblNganHangCauHoi where MaCauHoi={0}",macau);
            return da.executeQueryDataSet(sql);
        }
        public bool XoaNganHangCauHoi(int macau)
        {
            return da.executeNonQuery("spXoaNganHangCauHoi", CommandType.StoredProcedure,
                new SqlParameter("@MaCauHoi", macau));
        }
        public bool ThemNganHangCauHoi(string noidung, string a, string b, string c,string d,string dapan)
        {
            return da.executeNonQuery("spThemNganHangCauHoi", CommandType.StoredProcedure,
                new SqlParameter("@NoiDungCauHoi", noidung),
                new SqlParameter("@A", a),
                new SqlParameter("@B", b),
                new SqlParameter("@C", c),
                new SqlParameter("@D", d),
                new SqlParameter("@DapAn", dapan));
        }
        public bool CapNhatNganHangCauHoi(int macau,string noidung, string a, string b, string c, string d, string dapan)
        {
            return da.executeNonQuery("spCapNhatNganHangCauHoi", CommandType.StoredProcedure,
                new SqlParameter("@MaCau", macau),
                new SqlParameter("@NoiDungCauHoi", noidung),
                new SqlParameter("@A", a),
                new SqlParameter("@B", b),
                new SqlParameter("@C", c),
                new SqlParameter("@D", d),
                new SqlParameter("@DapAn", dapan));
        }
    }
}
