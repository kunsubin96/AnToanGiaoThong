using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data.SqlClient;
using System.Data;
namespace bussinessAccessLayer.Admin
{
    
    public class Luat
    {
        dataAccess da;
        public Luat()
        {
            da = new dataAccess();
        }
        public DataSet getThongTu()
        {
            string sql = string.Format("select MaThongTu, Ngay, NoiDung from tblThongTu");
            return da.executeQueryDataSet(sql);
        }
        public bool ThemThongTu(string mathongtu,  DateTime ngay, string noidung)
        {
            return da.executeNonQuery("spThemThongTu", CommandType.StoredProcedure,
                new SqlParameter("@MaThongTu", mathongtu),
                new SqlParameter("@Ngay", ngay),
                new SqlParameter("@NoiDung", noidung)
                );
        }
        public bool CapNhatThongTu(string mathongtu,  DateTime ngay, string noidung)
        {
            return da.executeNonQuery("spCapNhatThongTu", CommandType.StoredProcedure,
                new SqlParameter("@MaThongTu", mathongtu),
                new SqlParameter("@Ngay", ngay),
                new SqlParameter("@NoiDung", noidung)
                );
        }
        public bool XoaThongTu(string mathongtu)
        {
            return da.executeNonQuery("spXoaThongTu", CommandType.StoredProcedure,
                new SqlParameter("@MaThongTu", mathongtu)
                );
        }
        public DataSet getMucPhat()
        {
            string sql = string.Format("select * from tblTraCuuMucPhat");
            return da.executeQueryDataSet(sql);
        }
        public bool ThemMucPhat(float batdau, float ketthuc, string noidung)
        {
            return da.executeNonQuery("spThemMucPhat", CommandType.StoredProcedure,
                new SqlParameter("@BatDau", batdau),
                new SqlParameter("@KetThuc", ketthuc),
                new SqlParameter("@NoiDungPhat", noidung)
                );
        }
        public bool CapNhatMucPhat(int maMucPhat,float batdau, float ketthuc, string noidung)
        {
            return da.executeNonQuery("spCapNhatMucPhat", CommandType.StoredProcedure,
                new SqlParameter("@MaMucPhat", maMucPhat),
                new SqlParameter("@BatDau", batdau),
                new SqlParameter("@KetThuc", ketthuc),
                new SqlParameter("@NoiDungPhat", noidung)
                );
        }
        public bool XoaMucPhat(int maMucPhat)
        {
            return da.executeNonQuery("spXoaMucPhat", CommandType.StoredProcedure,
                new SqlParameter("@MaMucPhat", maMucPhat)
                );
        }
        public DataSet getLuatGiaoThong()
        {
            string sql = string.Format("select TT, SoDieu, NoiDungDieu from tblChiTietChuong order by TT");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getHocLuatGiaoThong()
        {
            string sql = string.Format("select * from tblHocLuatGiaoThong");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getTenChuongTheoMa(string machuong)
        {
            string sql = string.Format("select * from tblHocLuatGiaoThong where MaChuong='{0}'",machuong);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getMaChuong_TenChuongTheoSoDieu(int tt)
        {
            string sql = string.Format("select tblHocLuatGiaoThong.MaChuong, TenChuong from tblHocLuatGiaoThong, tblChiTietChuong where tblHocLuatGiaoThong.MaChuong=tblChiTietChuong.MaChuong and TT={0}",tt);
            return da.executeQueryDataSet(sql);
        }
        public bool XoaChiTietChuong(int  TT)
        {
            return da.executeNonQuery("spXoaChiTietChuong", CommandType.StoredProcedure,
                new SqlParameter("@TT", TT)
                );
        }
        public bool CapNhatHocLuatGiaoThong(string MaChuong, string TenChuong,  int  TT, string  SoDieu, string NoiDung)
        {
            return da.executeNonQuery("spCapNhatHocLuatGiaoThong", CommandType.StoredProcedure,
                new SqlParameter("@MaChuong", MaChuong),
                new SqlParameter("@TenChuong", TenChuong),
                new SqlParameter("@TT", TT),
                new SqlParameter("@SoDieu", SoDieu),
                new SqlParameter("@NoiDungDieu", NoiDung)
                );
        }

        public bool ThemHocLuat_ChiTiet(string MaChuong, string TenChuong, string SoDieu, string NoiDung)
        {
            return da.executeNonQuery("spThemHocLuat_ChiTiet", CommandType.StoredProcedure,
                new SqlParameter("@MaChuong", MaChuong),
                new SqlParameter("@TenChuong", TenChuong),
                new SqlParameter("@SoDieu", SoDieu),
                new SqlParameter("@NoiDungDieu", NoiDung)
                );
        }
        public bool ThemChiTietChuong(string MaChuong, string SoDieu, string NoiDung)
        {
            return da.executeNonQuery("spThemChiTietChuong", CommandType.StoredProcedure,
                new SqlParameter("@MaChuong", MaChuong),
                new SqlParameter("@SoDieu", SoDieu),
                new SqlParameter("@NoiDungDieu", NoiDung)
                );
        }
        public DataSet testMaChuong(string MaChuong)
        {
            string sql = string.Format("select * from tblHocLuatGiaoThong where  MaChuong='{0}'", MaChuong);
            return da.executeQueryDataSet(sql);
        }
    }
}
