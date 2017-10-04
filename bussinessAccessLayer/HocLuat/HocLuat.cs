using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using System.Data;
namespace bussinessAccessLayer.HocLuat
{
    public class HocLuat
    {
        dataAccess da;
        public HocLuat()
        {
            da = new dataAccess();
        }
        public DataSet getAllThongTu()
        {
            string sql = string.Format("select * from tblThongTu order by Ngay desc");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getAllDate()
        {
            string sql = string.Format("select DISTINCT Ngay from tblThongTu order by Ngay desc");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getNoiDungThongTu(string ngay)
        {
            string sql = string.Format("select * from tblThongTu where Ngay='{0}'",ngay);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getAllLuatGiaoThong()
        {
            string sql = string.Format("select * from tblHocLuatGiaoThong");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getDieuTheoChuong(string machuong)
        {
            string sql = string.Format("select * from tblChiTietChuong where MaChuong='{0}' order by SoDieu", machuong);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getChuong(string ten)
        {
            string sql = string.Format("select * from tblHocLuatGiaoThong where TenChuong like N'{0}:%'", ten);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getDieuCuaChuong(string machuong)
        {
            string sql = string.Format("select SoDieu, NoiDungDieu from tblChiTietChuong where MaChuong='{0}'", machuong);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getNoiDungDieu(string DieuSo)
        {
            string sql = string.Format("select SoDieu, NoiDungDieu from tblChiTietChuong where SoDieu like N'{0}.%'", DieuSo);
            return da.executeQueryDataSet(sql);
        }
        public DataSet getKhoangPhat()
        {
            string sql = string.Format("select DISTINCT BatDau, KetThuc from tblTraCuuMucPhat");
            return da.executeQueryDataSet(sql);
        }
        public DataSet getNoiDungPhat(float batDau, float ketThuc)
        {
            string sql = string.Format("select NoiDungPhat from tblTraCuuMucPhat where BatDau={0} and KetThuc={1}",batDau,ketThuc);
            return da.executeQueryDataSet(sql);
        }
    }
}
