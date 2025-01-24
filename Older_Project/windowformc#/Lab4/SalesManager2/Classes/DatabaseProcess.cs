using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.SqlClient;

namespace SalesManager2.Classes
{
    class DatabaseProcess
    {
        string strConnect = "Data Source=DESKTOP-N1I5QPD\\MSSQLSERVER03;" +
            "Initial Catalog=SalesManager;" +
            "User ID=sa;Password=sa";

        SqlConnection conn = null;

        void OpenConnect()
        {
            conn = new SqlConnection(strConnect);
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        void CloseConnect()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataTable DataReader(string sqlSelect)
        {
            DataTable tblData = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, conn);
            sqlData.Fill(tblData);
            CloseConnect();
            return tblData;
        }

        public void DataChange(string sql)
        {
            OpenConnect();
            SqlCommand sqlcomma = new SqlCommand();
            sqlcomma.Connection = conn;
            sqlcomma.CommandText = sql;
            sqlcomma.ExecuteNonQuery();
            CloseConnect();
        }

        public SqlDataReader dataReader(string sql)
        {
            OpenConnect();
            SqlCommand sqlcomma = new SqlCommand();
            sqlcomma.Connection = conn;
            sqlcomma.CommandText = sql;
            return sqlcomma.ExecuteReader();
        }
    }
}
