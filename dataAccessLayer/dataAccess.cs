using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace dataAccessLayer
{
    public class dataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public dataAccess()
        {
            try
            {
                System.Diagnostics.Debug.Write(connectionString);
                conn=new SqlConnection(this.connectionString);
                cmd=conn.CreateCommand();
            }
            catch (SqlException)
            {
                System.Diagnostics.Debug.Write("Catch error at dataAccess");
            }
        }
        public DataSet executeQueryDataSet(string sql)
        {
            cmd.CommandText=sql;
            cmd.CommandType=CommandType.Text;
            da=new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool executeNonQuery(string sql, CommandType ct,

            params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn=new SqlConnection(this.connectionString);
            cmd=conn.CreateCommand();
            conn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText=sql;
            cmd.CommandType=ct;

            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            try
            {
                cmd.ExecuteNonQuery();
                f=true;
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public int checkUserLogin(string comdText, CommandType type
          , params SqlParameter[] param)
        {
            int result = -1;
            //
            cmd.Parameters.Clear();
            cmd.CommandType=type;
            cmd.CommandText=comdText;

            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn.Open();
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            try
            {
                result=(int)cmd.ExecuteScalar();
                System.Diagnostics.Debug.Write(result);
            }
            catch (SqlException)
            {

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public DataSet ExcuteSP(string sql, CommandType ct,

            params SqlParameter[] param)
        {
            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn=new SqlConnection(this.connectionString);
            cmd=conn.CreateCommand();
            conn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText=sql;
            cmd.CommandType=ct;
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
        public string getConnectionString()
        {
            return this.connectionString;
        }


    }
}
