using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesManager.Classes
{
	internal class DataBaseProcess
	{
		string strConnect = "Data Source=DUCNHU;" +
			"Initial Catalog=SalesManager;" +
			"User ID=sa;Password=sa";

		SqlConnection sqlConnect = null;

		// Phương thức mở kết nối
		void OpenConnect()
		{
			sqlConnect = new SqlConnection(strConnect);
			if (sqlConnect.State != ConnectionState.Open)
			{
				sqlConnect.Open();
				Console.WriteLine("Connected");
			}
		}

		// Phương thức đóng kết nối
		public void CloseConnect()
		{
			if (sqlConnect.State != ConnectionState.Closed)
			{
				sqlConnect.Close();
				sqlConnect.Dispose();
			}
		}

		//Phương thức thực thi câu lệnh Select trả về một DataTable
		public DataTable DataReader(string sqlSelct)
		{
			DataTable tblData = new DataTable();
			OpenConnect();
			SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelct, sqlConnect);
			sqlData.Fill(tblData);
			CloseConnect();
			return tblData;
		}

		//Phương thức thực hiện câu lệnh dạng insert,update,delete
		public void DataChange(string sql)
		{
			OpenConnect();
			SqlCommand sqlcomma = new SqlCommand();
			sqlcomma.Connection = sqlConnect;
			sqlcomma.CommandText = sql;
			sqlcomma.ExecuteNonQuery();
			CloseConnect();
		}
	}
}
