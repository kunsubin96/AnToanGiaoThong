using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using dataAccessLayer;
namespace bussinessAccessLayer.Thi
{
    public class ThiTracNghiemBA
    {
        dataAccess da;

        public ThiTracNghiemBA()
        {
            da=new dataAccess();
        }
        public bool CapNhatDapAn(string malanthi, int macauhoi, string dapanchon)
        {
            return da.executeNonQuery("spCapNhatDapAnChon", CommandType.StoredProcedure,
              new SqlParameter("@malanthi", malanthi),
                new SqlParameter("@macauhoi", macauhoi),
                 new SqlParameter("@dapanchon", dapanchon));
        }
        public bool CapNhatDiem(string malanthi,double diem)
        {
            return da.executeNonQuery("spCapNhatDiem", CommandType.StoredProcedure,
              new SqlParameter("@malanthi", malanthi),
                new SqlParameter("@diem", diem));
        }
        public bool ThemChiTietThi(string malanthi, int macauhoi)
        {
            return da.executeNonQuery("spThemChiTietThi", CommandType.StoredProcedure,
              new SqlParameter("@malanthi", malanthi),
                new SqlParameter("@macauhoi", macauhoi));
        }
        public bool ThemThiTracNghiem(DateTime thoigianthi,string username)
        {
            return da.executeNonQuery("spThemThiTracNghiem", CommandType.StoredProcedure,
            new SqlParameter("@thoigianthi", thoigianthi),
              new SqlParameter("@username", username));
        }
        public int getMaLanThiMoiNhat()
        {
            string sql = string.Format("select [dbo].[F_LayMaLanThiMoiNhat]()");
           return da.executeQueryDataSet(sql).Tables[0].Rows.Count>0 ?int.Parse( da.executeQueryDataSet(sql).Tables[0].Rows[0][0].ToString()):-1;
        }

        public string KiemTraDapAn(string macauhoi)
        {
            string sql = string.Format("select [dbo].[F_LayDapAnCauHoi]('{0}')", macauhoi);
            return da.executeQueryDataSet(sql).Tables[0].Rows.Count>0 ?da.executeQueryDataSet(sql).Tables[0].Rows[0][0].ToString() : "-1";
        }
        public bool XoaChiTietThi(string malanthi)
        {
            return da.executeNonQuery("spXoaChiTietThi", CommandType.StoredProcedure, new SqlParameter("@malanthi", malanthi));
        }

    }//end class
}
