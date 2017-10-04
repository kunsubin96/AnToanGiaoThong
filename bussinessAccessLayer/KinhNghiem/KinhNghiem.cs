using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using dataAccessLayer;
using System.Data;
//
namespace bussinessAccessLayer.KinhNghiem
{
    public class KinhNghiem
    {
        dataAccess da;
        public KinhNghiem()
        {
            da = new dataAccess();
        }
        public DataSet LayLoaiKinhNghiem()
        {
            string sql = string.Format("select * from tblLoaiKinhNghiem");
            return da.executeQueryDataSet(sql);
        }
        public bool ThemLoaiKinhNghiem(string TenKinhNghiem)
        {
            return da.executeNonQuery("spThemLoaiKinhNghiem", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@TenLoaiKN", TenKinhNghiem));
        }
        public bool UpdateLoaiKinhNghiem(int MaLoaiKN, string TenKinhNghiem)
        {
            return da.executeNonQuery("spCapNhatLoaiKinhNghiem", CommandType.StoredProcedure,
                 new System.Data.SqlClient.SqlParameter("@MaLoaiKN", MaLoaiKN),
                new System.Data.SqlClient.SqlParameter("@TenLoaiKN", TenKinhNghiem));
        }
        public bool XoaLoaiKinhNghiem(int MaLoaiKN)
        {
            return da.executeNonQuery("spXoaLoaiKinhNghiem", CommandType.StoredProcedure,
                 new System.Data.SqlClient.SqlParameter("@MaLoaiKN", MaLoaiKN));
        }

        // KinhNghiem
        public DataSet LayKinhNghiem()
        {
            string sql = string.Format("select * from tblKinhNghiem");
            return da.executeQueryDataSet(sql);
        }
        public bool ThemKinhNghiem(string TenKinhNghiem, string NoiDungKN, int LoaiKN)
        {
            return da.executeNonQuery("spThemKinhNghiem", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@TenKinhNghiem", TenKinhNghiem),
                new System.Data.SqlClient.SqlParameter("@NoiDungKN", NoiDungKN),
                new System.Data.SqlClient.SqlParameter("@MaLoaiKN", LoaiKN));
        }
        public bool UpdateKinhNghiem(int MaKN, string TenKinhNghiem, string NoiDungKN, int LoaiKN)
        {
            return da.executeNonQuery("spCapNhatKinhNghiem", CommandType.StoredProcedure,
                new System.Data.SqlClient.SqlParameter("@MaKN", MaKN),
                new System.Data.SqlClient.SqlParameter("@TenKinhNghiem", TenKinhNghiem),
                new System.Data.SqlClient.SqlParameter("@NoiDungKN", NoiDungKN),
                new System.Data.SqlClient.SqlParameter("@MaLoaiKN", LoaiKN));
        }
        public bool XoaKinhNghiem(int MaKN)
        {
            return da.executeNonQuery("spXoaKinhNghiem", CommandType.StoredProcedure,
                 new System.Data.SqlClient.SqlParameter("@MaKN", MaKN));
        }
    }
}

