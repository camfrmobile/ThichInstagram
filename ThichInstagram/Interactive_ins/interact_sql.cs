using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Interactive_ins
{
	public class interact_sql
	{
		private SQLiteConnection _con = null;

		private string path = "interact.sqlite";

		public void createConection()
		{
			string connectionString = "Data Source=" + path + ";Version=3;";
			if (_con == null)
			{
				_con = new SQLiteConnection(connectionString);
			}
			if (_con.State == ConnectionState.Closed)
			{
				_con.Open();
			}
		}

		public void closeConnection()
		{
			_con.Close();
		}

		public void Check_table()
		{
			if (!File.Exists(path))
			{
				createTable_KichBan();
				createTable_HanhDong();
			}
		}

		public void createTable_KichBan()
		{
			string commandText = "CREATE TABLE Kich_Ban (ID_KichBan INTEGER PRIMARY KEY AUTOINCREMENT, STT nvarchar(50), TenKichBan nvarchar(50) )";
			try
			{
				SQLiteConnection.CreateFile(path);
			}
			catch
			{
			}
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			sQLiteCommand.ExecuteNonQuery();
			closeConnection();
		}

		public void createTable_HanhDong()
		{
			string commandText = "CREATE TABLE Hanh_Dong (ID_HanhDong INTEGER PRIMARY KEY AUTOINCREMENT, STT nvarchar(50), ID_KichBan nvarchar(50), TenHanhDong nvarchar(50), CauHinh nvarchar(1000), Ma_HanhDong nvarchar(50) )";
			try
			{
				SQLiteConnection.CreateFile(path);
			}
			catch
			{
			}
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			sQLiteCommand.ExecuteNonQuery();
			closeConnection();
		}

		public DataTable ExecuteQuery(string query)
		{
			DataTable dataTable = new DataTable();
			try
			{
				createConection();
				SQLiteCommand cmd = new SQLiteCommand(query, _con);
				SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd);
				sQLiteDataAdapter.Fill(dataTable);
			}
			catch
			{
			}
			return dataTable;
		}

		public DataTable LoadData_KichBan()
		{
			createConection();
			return ExecuteQuery("select ID_KichBan as [ID_KichBan], STT as [STT], TenKichBan as [TenKichBan] from Kich_Ban");
		}

		public DataTable LoadData_HanhDong()
		{
			createConection();
			return ExecuteQuery("select ID_HanhDong as [ID_HanhDong], STT as [STT], ID_KichBan as [ID_KichBan], TenHanhDong as [TenHanhDong], CauHinh as [CauHinh], Ma_HanhDong as [Ma_HanhDong] from Hanh_Dong");
		}

		public Thongso_KichBan Select_Data_KichBan(string TenKichBan)
		{
			string query = "SELECT * from Kich_Ban WHERE TenKichBan = '" + TenKichBan + "'";
			Thongso_KichBan thongso_KichBan = new Thongso_KichBan();
			DataTable dataTable = ExecuteQuery(query);
			if (dataTable.Rows.Count != 0)
			{
				DataRow dataRow = dataTable.Rows[0];
				thongso_KichBan.ID_KichBan = dataRow["ID_KichBan"].ToString();
				thongso_KichBan.TenKichBan = dataRow["TenKichBan"].ToString();
			}
			return thongso_KichBan;
		}

		public Thongso_HanhDong Select_Data_HanhDong(string ID_HanhDong)
		{
			string query = "SELECT * from Hanh_Dong WHERE ID_HanhDong = '" + ID_HanhDong + "'";
			Thongso_HanhDong thongso_HanhDong = new Thongso_HanhDong();
			DataTable dataTable = ExecuteQuery(query);
			DataRow dataRow = dataTable.Rows[0];
			thongso_HanhDong.ID_HanhDong = dataRow["ID_HanhDong"].ToString();
			thongso_HanhDong.ID_KichBan = dataRow["ID_KichBan"].ToString();
			thongso_HanhDong.TenHanhDong = dataRow["TenHanhDong"].ToString();
			thongso_HanhDong.CauHinh = dataRow["CauHinh"].ToString();
			thongso_HanhDong.Ma_HanhDong = int.Parse(dataRow["Ma_HanhDong"].ToString());
			return thongso_HanhDong;
		}

		public void Add_data_KichBan(string TenKichBan)
		{
			string commandText = "INSERT INTO Kich_Ban(TenKichBan) \r\n                    VALUES(@TenKichBan)";
			createConection();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@TenKichBan", TenKichBan));
				try
				{
					sQLiteCommand.ExecuteNonQuery();
				}
				catch
				{
				}
				try
				{
					sQLiteTransaction.Commit();
				}
				catch
				{
				}
			}
			stopwatch.Stop();
		}

		public void Update_Data_HanhDong(Thongso_HanhDong Thongso_HanhDong)
		{
			createConection();
			string commandText = "UPDATE Hanh_Dong set TenHanhDong=@TenHanhDong, CauHinh=@CauHinh where ID_HanhDong=@ID_HanhDong";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@ID_HanhDong", Thongso_HanhDong.ID_HanhDong));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@TenHanhDong", Thongso_HanhDong.TenHanhDong));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@CauHinh", Thongso_HanhDong.CauHinh));
				try
				{
					if (req._req != 0)
					{
						sQLiteCommand.ExecuteNonQuery();
						sQLiteTransaction.Commit();
					}
				}
				catch
				{
				}
			}
			stopwatch.Stop();
		}

		public void Add_data_HanhDong(Thongso_HanhDong Thongso_HanhDong)
		{
			string commandText = "INSERT INTO Hanh_Dong(ID_KichBan,TenHanhDong,CauHinh,Ma_HanhDong) \r\n                    VALUES(@ID_KichBan,@TenHanhDong,@CauHinh,@Ma_HanhDong)";
			createConection();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@ID_KichBan", Thongso_HanhDong.ID_KichBan));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@TenHanhDong", Thongso_HanhDong.TenHanhDong));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@CauHinh", Thongso_HanhDong.CauHinh));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@Ma_HanhDong", Thongso_HanhDong.Ma_HanhDong));
				try
				{
					sQLiteCommand.ExecuteNonQuery();
				}
				catch
				{
				}
				try
				{
					sQLiteTransaction.Commit();
				}
				catch
				{
				}
			}
			stopwatch.Stop();
		}

		public void Delete_Data_KichBan(string ID_KichBan)
		{
			string commandText = "DELETE FROM Kich_Ban where ID_KichBan ='" + ID_KichBan + "'";
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			try
			{
				sQLiteCommand.ExecuteNonQuery();
			}
			catch
			{
			}
			closeConnection();
		}

		public void Update_Data_KichBan(string TenKichBan, string ID_KichBan)
		{
			createConection();
			string commandText = "UPDATE Kich_Ban set TenKichBan=@TenKichBan where ID_KichBan=@ID_KichBan";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@TenKichBan", TenKichBan));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@ID_KichBan", ID_KichBan));
				try
				{
					if (tt_kk._key.Length == 17)
					{
						sQLiteCommand.ExecuteNonQuery();
					}
					sQLiteTransaction.Commit();
				}
				catch
				{
				}
			}
			stopwatch.Stop();
		}

		public void Delete_Data_HanhDong(string ID_HanhDong)
		{
			string commandText = "DELETE FROM Hanh_Dong where ID_HanhDong ='" + ID_HanhDong + "'";
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			try
			{
				if (tt_kk._key.Length == 17)
				{
					sQLiteCommand.ExecuteNonQuery();
				}
			}
			catch
			{
			}
			closeConnection();
		}

		public void Delete_Data_HanhDong_1(string ID_KichBan)
		{
			string commandText = "DELETE FROM Hanh_Dong where ID_KichBan ='" + ID_KichBan + "'";
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			try
			{
				sQLiteCommand.ExecuteNonQuery();
			}
			catch
			{
			}
			closeConnection();
		}
	}
}
