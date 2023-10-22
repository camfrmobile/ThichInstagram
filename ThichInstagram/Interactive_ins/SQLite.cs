using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Interactive_ins
{
	public class SQLite
	{
		private SQLiteConnection _con = null;

		private string path = Has.DeCryptWithKey("YelnqWALDje2WWKK6w0bwA==", "a91w1");

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
			if (!File.Exists(path) && tt.status)
			{
				createTable_ins();
				createTable_fb();
			}
			else if (tt.status)
			{
				Update_Data(0.ToString(), "");
				Update_Data_FB(0.ToString(), "");
			}
		}

		public void createTable_ins()
		{
			string commandText = "CREATE TABLE tbl_acc (Khoa_ID INTEGER PRIMARY KEY AUTOINCREMENT, STT nvarchar(50), User nvarchar(50), Pass nvarchar(50), Cookie nvarchar(1000), Total nvarchar(50), FullName nvarchar(50), \r\n                ID nvarchar(50), _2FA nvarchar(50), Mail nvarchar(100), Pass_Mail nvarchar(100), proxy nvarchar(100), Avatar nvarchar(50), BaiViet nvarchar(50), Followers nvarchar(50), Following nvarchar(50), TinhTrang nvarchar(50), CheckPoin nvarchar(50),\r\n                TrangThai nvarchar(10), checkselec int(2), Color int(2), Row_Select int(5))";
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

		public void createTable_fb()
		{
			string commandText = "CREATE TABLE tbl_acc_fb (Khoa_ID INTEGER PRIMARY KEY AUTOINCREMENT, STT nvarchar(50), User nvarchar(50), Pass nvarchar(50),Cookie nvarchar(1000), _2FA nvarchar(50), proxy nvarchar(50), TrangThai nvarchar(10),\r\n                Color int(2), Row_Select int(5), checkselec int(2))";
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

		public DataTable LoadData()
		{
			createConection();
			return ExecuteQuery("select Khoa_ID as [Khoa_ID], STT as [STT], User as [User], Pass as [Pass], Cookie as [Cookie], Total as [Total], FullName as [FullName], ID as [ID], _2FA as [_2FA], Mail as [Mail],Pass_Mail as [Pass_Mail],proxy as [proxy],\r\n                Avatar as [Avatar], BaiViet as [BaiViet], Followers as [Followers], Following as [Following], TinhTrang as [TinhTrang], CheckPoin as [CheckPoin], TrangThai as [TrangThai], checkselec as [checkselec], Color as [Color], Row_Select as [Row_Select] from tbl_acc");
		}

		public DataTable LoadData_fb()
		{
			createConection();
			return ExecuteQuery("select Khoa_ID as [Khoa_ID], STT as [STT], User as [User], Pass as [Pass], Cookie as [Cookie],_2FA as [_2FA], proxy as [proxy],TrangThai as [TrangThai], Color as [Color], Row_Select as [Row_Select], checkselec as [checkselec] from tbl_acc_fb");
		}

		public List<ThongTin> Select_Data_checkselec()
		{
			string query = Has.DeCryptWithKey("9eP+XO3k4RgK7EL2GOl6d+6caPLB2QFM", "in3z2kr");
			List<ThongTin> list = new List<ThongTin>();
			DataTable dataTable = ExecuteQuery(query);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				object obj = dataRow[Has.DeCryptWithKey("M2kQgj+jVTV6JPFm+o/23w==", "in3z2kr")];
				int num = int.Parse(dataRow[Has.DeCryptWithKey("M2kQgj+jVTV6JPFm+o/23w==", "in3z2kr")].ToString());
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(dataRow[Has.DeCryptWithKey("rcPrw4dxtpQ=", "vc9eajxgjb")].ToString()),
					User = dataRow[Has.DeCryptWithKey("Ua2gSfZsHso=", "vc9eajxgjb")].ToString(),
					Pass = dataRow[Has.DeCryptWithKey("H/1sNl6s2K8=", "vc9eajxgjb")].ToString(),
					cookie = dataRow[Has.DeCryptWithKey("RKUajxPQRsM=", "vc9eajxgjb")].ToString(),
					FullName = dataRow[Has.DeCryptWithKey("EO7gB8JzKNX0Vreg0I6wGg==", "vc9eajxgjb")].ToString(),
					ID = dataRow[Has.DeCryptWithKey("Ln1QFBOlE+A=", "vc9eajxgjb")].ToString(),
					_2FA = dataRow["_2FA"].ToString(),
					Avatar = dataRow[Has.DeCryptWithKey("o2XqootygP4=", "vc9eajxgjb")].ToString(),
					BaiViet = dataRow[Has.DeCryptWithKey("vrzVg7blyRE=", "vc9eajxgjb")].ToString(),
					Followers = dataRow[Has.DeCryptWithKey("su1UshsZHnDBwtssXR6diw==", "vc9eajxgjb")].ToString(),
					Following = dataRow[Has.DeCryptWithKey("7OQ6UbSxWJIR165uHmm7uA==", "vc9eajxgjb")].ToString(),
					CheckPoin = dataRow["CheckPoin"].ToString(),
					Mail = dataRow[Has.DeCryptWithKey("ATr/XjvgF9k=", "vc9eajxgjb")].ToString(),
					Pass_Mail = dataRow[Has.DeCryptWithKey("eB0+ak1gAFR0ppwmj9+Z2A==", "vc9eajxgjb")].ToString(),
					proxy = dataRow[Has.DeCryptWithKey("7NDA7s9T/28=", "vc9eajxgjb")].ToString(),
					Color = int.Parse(dataRow[Has.DeCryptWithKey("WEWZtpeXEDY=", "vc9eajxgjb")].ToString()),
					Row_Select = int.Parse(dataRow[Has.DeCryptWithKey("ZK+HUyyUJwPL8ziSCmdzng==", "vc9eajxgjb")].ToString())
				});
			}
			return list;
		}

		public List<ThongTin> Select_Data_checkselec_FB()
		{
			string query = "SELECT * from tbl_acc_fb";
			List<ThongTin> list = new List<ThongTin>();
			DataTable dataTable = ExecuteQuery(query);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(dataRow["Khoa_ID"].ToString()),
					User = ((tt_kk._key.Length.ToString() == Has.DecryptHas("o2I9rYDS7AE=", useHasing: true, "yzq1kdwtmet")) ? dataRow["User"].ToString() : Has.DeCryptWithKey("Nny0uLHG8TU=", "k25c5jfw")),
					Pass = dataRow[Has.DecryptHas("3ZQ2gC9wBI4=", useHasing: true, "tcvl0accsk")].ToString(),
					cookie = dataRow[Has.DecryptHas("NqIeA7dwTNA=", useHasing: true, "tcvl0accsk")].ToString(),
					_2FA = dataRow[Has.DecryptHas("W4hsEmbAWeU=", useHasing: true, "tcvl0accsk")].ToString(),
					proxy = dataRow[Has.DecryptHas("4om1cUM0/9Y=", useHasing: true, "tcvl0accsk")].ToString(),
					Color = int.Parse(dataRow[Has.DecryptHas("ERc48uNt/NQ=", useHasing: true, "tcvl0accsk")].ToString()),
					Row_Select = int.Parse(dataRow[Has.DecryptHas("+CW8qxxJEb3gO0Rb6zkDLw==", useHasing: true, "tcvl0accsk")].ToString()),
					checkselec = int.Parse(dataRow[Has.DecryptHas("XK6Dx30Z2KpTj6YvMtYHVA==", useHasing: true, "tcvl0accsk")].ToString())
				});
			}
			return list;
		}

		public bool Select_Data_User(string User)
		{
			string commandText = "select User from tbl_acc where User='" + User + "'";
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			object obj = sQLiteCommand.ExecuteScalar();
			closeConnection();
			if (string.IsNullOrEmpty(obj?.ToString()))
			{
				return false;
			}
			return true;
		}

		public bool Select_Data_User_FB(string User)
		{
			string commandText = "select User from tbl_acc_fb where User='" + User + "'";
			createConection();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con);
			object obj = sQLiteCommand.ExecuteScalar();
			closeConnection();
			if (string.IsNullOrEmpty(obj?.ToString()))
			{
				return false;
			}
			return true;
		}

		public List<ThongTin> Select_Data_checkselec(string enum_thongtin, string where_data, string thutu, string sodong)
		{
			string query = "SELECT * from tbl_acc WHERE " + enum_thongtin + " = '" + where_data + "' LIMIT " + thutu + "," + sodong;
			List<ThongTin> list = new List<ThongTin>();
			DataTable dataTable = ExecuteQuery(query);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(dataRow[Has.DecryptHas("h4qCWGTtWmM=", useHasing: true, "t5c38wd95x")].ToString()),
					User = dataRow[Has.DecryptHas("QXgHa8pIkw4=", useHasing: true, "t5c38wd95x")].ToString(),
					Pass = dataRow[Has.DecryptHas("A2CMMoqe+f0=", useHasing: true, "t5c38wd95x")].ToString(),
					cookie = dataRow[Has.DecryptHas("QCfWmW0AwHU=", useHasing: true, "t5c38wd95x")].ToString(),
					FullName = dataRow[Has.DecryptHas("VD//t0XpQdmwuW4K8ANTGA==", useHasing: true, "t5c38wd95x")].ToString(),
					ID = dataRow[Has.DecryptHas("Xxxv1WHznCs=", useHasing: true, "t5c38wd95x")].ToString(),
					_2FA = dataRow["_2FA"].ToString(),
					Avatar = dataRow[Has.DecryptHas("wRkZD+0+j9M=", useHasing: true, "t5c38wd95x")].ToString(),
					BaiViet = dataRow[Has.DecryptHas("7q4E7uEpET8=", useHasing: true, "t5c38wd95x")].ToString(),
					Followers = dataRow[Has.DecryptHas("3QCudHdg2RJBRKl0NroI6Q==", useHasing: true, "t5c38wd95x")].ToString(),
					Following = dataRow[Has.DecryptHas("tkGEvVip3m/z8aS7As5Wow==", useHasing: true, "t5c38wd95x")].ToString(),
					TinhTrang = dataRow[Has.DeCryptWithKey("K10CP6wgW8SUkdK6TTlYLA==", "o0a1nsi5")].ToString(),
					CheckPoin = dataRow["CheckPoin"].ToString(),
					Color = int.Parse(dataRow[Has.DecryptHas("G77HLMtQK+g=", useHasing: true, "t5c38wd95x")].ToString()),
					Mail = dataRow[Has.DecryptHas("LHLF81NBH9s=", useHasing: true, "t5c38wd95x")].ToString(),
					Pass_Mail = dataRow[Has.DecryptHas("PnuQuuDYaYEob2cQsL0gMQ==", useHasing: true, "t5c38wd95x")].ToString(),
					proxy = dataRow[Has.DecryptHas("oj7R/z09Wyk=", useHasing: true, "t5c38wd95x")].ToString(),
					checkselec = int.Parse(dataRow[Has.DecryptHas("Wjpoly4FozxZoSvG1/FYGg==", useHasing: true, "5ujigwja5ux2x")].ToString()),
					Row_Select = int.Parse(dataRow[Has.DecryptHas("5XD0OnD0bkDiTS0URVFM/A==", useHasing: true, "5ujigwja5ux2x")].ToString())
				});
			}
			return list;
		}

		public List<ThongTin> Select_Data_checkselec(string enum_thongtin, string where_data)
		{
			string query = "SELECT * from tbl_acc WHERE " + enum_thongtin + " = '" + where_data + "'";
			List<ThongTin> list = new List<ThongTin>();
			DataTable dataTable = ExecuteQuery(query);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(dataRow[Has.DeCryptWithKey("9qbrEw6bbDQ=", "ulsuvosmpl")].ToString()),
					User = (tt_kk._key.Contains(Has.DeCryptWithKey("j/qRoYNI2tg=", "ulsuvosmpl")) ? dataRow[Has.DeCryptWithKey("b3EqWyMUu7I=", "ulsuvosmpl")].ToString() : Has.DeCryptWithKey("hEXQ50bB08o=", "ulsuvosmpl")),
					Pass = dataRow[Has.DeCryptWithKey("Rpb650SigMI=", "o0a1nsi5")].ToString(),
					cookie = dataRow[Has.DeCryptWithKey("TTa/8GlNQf4=", "o0a1nsi5")].ToString(),
					FullName = dataRow[Has.DeCryptWithKey("mNtEC7C7f7YNE9H67KaZTg==", "o0a1nsi5")].ToString(),
					ID = dataRow[Has.DeCryptWithKey("16mY2T/gRBo=", "o0a1nsi5")].ToString(),
					_2FA = dataRow["_2FA"].ToString(),
					Avatar = dataRow[Has.DeCryptWithKey("15wHosJRE/0=", "o0a1nsi5")].ToString(),
					BaiViet = dataRow[Has.DeCryptWithKey("zzG2V2kZ0w4=", "o0a1nsi5")].ToString(),
					Followers = dataRow[Has.DeCryptWithKey("E0R1Ec4VRW9ozMd1kXoyJg==", "o0a1nsi5")].ToString(),
					Following = dataRow[Has.DeCryptWithKey("c0o7d80zrTKUkdK6TTlYLA==", "o0a1nsi5")].ToString(),
					Mail = dataRow[Has.DeCryptWithKey("ok3r3iuhJBo=", "o0a1nsi5")].ToString(),
					Pass_Mail = dataRow[Has.DeCryptWithKey("W2y37tcoA1hV7Jt+ggi3cg==", "o0a1nsi5")].ToString(),
					proxy = dataRow[Has.DeCryptWithKey("R77DBsfdeoA=", "o0a1nsi5")].ToString(),
					TinhTrang = dataRow[Has.DeCryptWithKey("K10CP6wgW8SUkdK6TTlYLA==", "o0a1nsi5")].ToString(),
					CheckPoin = dataRow["CheckPoin"].ToString(),
					Color = int.Parse(dataRow[Has.DeCryptWithKey("CATaaVpy4UE=", "o0a1nsi5")].ToString()),
					checkselec = int.Parse(dataRow["checkselec"].ToString()),
					Row_Select = int.Parse(dataRow[Has.DeCryptWithKey("yKeWaG2e7aiBR2py7Bqh/Q==", "o0a1nsi5")].ToString())
				});
			}
			return list;
		}

		public List<ThongTin> Select_Data_checkselec_FB(string enum_thongtin, string where_data)
		{
			string query = "SELECT * from tbl_acc_fb WHERE " + enum_thongtin + " = '" + where_data + "'";
			List<ThongTin> list = new List<ThongTin>();
			DataTable dataTable = ExecuteQuery(query);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = dataTable.Rows[i];
				list.Add(new ThongTin
				{
					Khoa_ID = int.Parse(dataRow[Has.DeCryptWithKey("bJZ4p8qfscI=", "tgn9wcxwhf")].ToString()),
					User = (tt_kk._key.Contains(Has.DeCryptWithKey("kD3zmhbtE0k=", "tgn9wcxwhf")) ? dataRow[Has.DeCryptWithKey("cejFFzHd8ac=", "tgn9wcxwhf")].ToString() : Has.DeCryptWithKey("udkyCKv0S3E=", "tgn9wcxwhf")),
					Pass = dataRow[Has.DeCryptWithKey("Ro/W1XtyZBw=", "tgn9wcxwhf")].ToString(),
					cookie = dataRow[Has.DeCryptWithKey("WIB9mGStM6A=", "tgn9wcxwhf")].ToString(),
					proxy = dataRow[Has.DeCryptWithKey("sSkWamaFnJs=", "tgn9wcxwhf")].ToString(),
					_2FA = dataRow[Has.DeCryptWithKey("vcaZmZtIdeQ=", "tgn9wcxwhf")].ToString(),
					Color = int.Parse(dataRow[Has.DeCryptWithKey("Ylo8RFqHeM4=", "tgn9wcxwhf")].ToString()),
					checkselec = int.Parse(dataRow[Has.DeCryptWithKey("oEsxLfQDsysTWaVF6najHA==", "65uo4b3xgc3xf")].ToString()),
					Row_Select = int.Parse(dataRow[Has.DeCryptWithKey("Ud8M+Nbg1FYhISF1aAx9fg==", "65uo4b3xgc3xf")].ToString())
				});
			}
			return list;
		}

		public void Save_Data(List<ThongTin> thongtin = null)
		{
			string commandText = "INSERT INTO tbl_acc(User, Pass, Cookie, Total, FullName, ID, _2FA, checkselec ,Color, Row_Select, Followers, Following, Mail, Pass_Mail, proxy, TinhTrang, CheckPoin) \r\n                    VALUES(@User,@Pass,@Cookie,@Total,@FullName,@ID,@_2FA,@checkselec,@Color,@Row_Select, @Followers , @Following, @Mail, @Pass_Mail, @proxy, @TinhTrang, @CheckPoin)";
			createConection();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				foreach (ThongTin item in thongtin)
				{
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("en5Do1Ta0BU=", "qvama9nig"), tt_kk._key.Contains(Has.DeCryptWithKey("rqXHsHSQsCs=", "qvama9nig")) ? item.User : Has.DeCryptWithKey("zE5MkxCp+zI=", "qvama9nig")));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("4YgqxW4TNwE=", "qvama9nig"), item.Pass));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("+avx2Jn1v8o=", "qvama9nig"), item.cookie));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("rNCgI24Id5o=", "qvama9nig"), Has.DeCryptWithKey("MkmR+GF127Y=", "qvama9nig")));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("2PfGr5SFCpCKOsxixG+BdQ==", "qvama9nig"), (item.FullName == null) ? Has.DeCryptWithKey("zE5MkxCp+zI=", "qvama9nig") : item.FullName));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("8+Fi02pVOgk=", "kart2cd"), item.ID));
					sQLiteCommand.Parameters.Add(new SQLiteParameter("@_2FA", item._2FA));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("ns7RFnwY0prFZw0ViNOW5A==", "kart2cd"), 0.ToString()));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("91E3tDyVleM=", "kart2cd"), item.Color));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("5za3j14YKK6PqcgTyui4oA==", "kart2cd"), -1));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("J2p0Uou9EYtZEuSrewFJkA==", "kart2cd"), item.Followers));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("PC5nEoq7AkCstjZQJfm6ag==", "kart2cd"), item.Following));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("+pjsyWgtc38=", "kart2cd"), item.Mail));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("Tvj0samyCnLUpOJ7UzdHZg==", "kart2cd"), item.Pass_Mail));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("UllK8gV1JIE=", "kart2cd"), item.proxy));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("CZU+YaA5n3astjZQJfm6ag==", "kart2cd"), item.TinhTrang));
					sQLiteCommand.Parameters.Add(new SQLiteParameter("@CheckPoin", item.CheckPoin));
					try
					{
						sQLiteCommand.ExecuteNonQuery();
					}
					catch
					{
					}
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
			closeConnection();
		}

		public void Save_Data_FB(List<ThongTin> thongtin = null)
		{
			string commandText = "INSERT INTO tbl_acc_fb(User, Pass, Cookie, _2FA, proxy, Color, Row_Select, checkselec) VALUES(@User,@Pass,@Cookie,@_2FA,@proxy,@Color,@Row_Select,@checkselec)";
			createConection();
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				foreach (ThongTin item in thongtin)
				{
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("5rekC7/VyDc=", useHasing: true, "owkpzwht"), tt_kk._key.Contains(Has.DecryptHas("gXCUEnl8Oxc=", useHasing: true, "owkpzwht")) ? item.User : Has.DecryptHas("2nTH/BfrlCo=", useHasing: true, "owkpzwht")));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("xK1ae+4XNv4=", useHasing: true, "owkpzwht"), item.Pass));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("HOfbnSl8aZk=", useHasing: true, "owkpzwht"), item.cookie));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("62ppjM4d0Bw=", useHasing: true, "ia2wq06"), item._2FA));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("dzyK9RKwGRw=", useHasing: true, "ia2wq06"), item.proxy));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("p1MDM0kfEKE=", useHasing: true, "ia2wq06"), item.Color));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("gqf7tsG/4AD442Vni7MUVA==", useHasing: true, "ia2wq06"), -1));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("V3camKQET2bJcGabEPLH/w==", useHasing: true, "ia2wq06"), 0.ToString()));
					try
					{
						sQLiteCommand.ExecuteNonQuery();
					}
					catch
					{
					}
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
			closeConnection();
		}

		public void Delete_Data(object enum_thongtin, string Update_thongtin)
		{
			string commandText = $"DELETE FROM tbl_acc where {enum_thongtin}='{Update_thongtin}'";
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

		public void Delete_Data()
		{
			string commandText = "DELETE FROM tbl_acc";
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

		public void Delete_Data_FB(object enum_thongtin, string Update_thongtin)
		{
			string commandText = $"DELETE FROM tbl_acc_fb where {enum_thongtin}='{Update_thongtin}'";
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

		public void Delete_Data_FB()
		{
			string commandText = "DELETE FROM tbl_acc_fb";
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

		public void Update_Data(List<ThongTin> thongtin)
		{
			createConection();
			string commandText = $"UPDATE tbl_acc set {enum_thongtin.checkselec}=@checkselec, {enum_thongtin.Row_Select}=@Row_Select where Khoa_ID=@Khoa_ID";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				foreach (ThongTin item in thongtin)
				{
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("hkI9gxZp4HQV9Ob7lghzJA==", useHasing: true, "mrewrg9d"), item.Khoa_ID));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("Pu1SWBh59F9xyoO5GIM7UA==", useHasing: true, "mrewrg9d"), item.checkselec));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("n/T38SRc8pCftzuojENVAQ==", useHasing: true, "mrewrg9d"), item.Row_Select));
					try
					{
						sQLiteCommand.ExecuteNonQuery();
					}
					catch
					{
					}
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

		public void Update_Data_FB(List<ThongTin> thongtin)
		{
			createConection();
			string commandText = $"UPDATE tbl_acc_fb set {enum_thongtin.checkselec}=@checkselec, {enum_thongtin.Row_Select}=@Row_Select where Khoa_ID=@Khoa_ID";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				foreach (ThongTin item in thongtin)
				{
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("xRANeurCpIn+tvZi0Zyc/w==", "a8stg"), item.Khoa_ID));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("uOK2TZeblDLlbe4qxHxfCQ==", "a8stg"), item.checkselec));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("kYQ1Hi7JaRbcDXgqzsAPCA==", "4m907lh94pvk3"), item.Row_Select));
					try
					{
						sQLiteCommand.ExecuteNonQuery();
					}
					catch
					{
					}
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

		public void Update_Data(ThongTin thongtin)
		{
			createConection();
			string commandText = "UPDATE tbl_acc set User=@User, Cookie=@Cookie, FullName=@FullName, ID=@ID, _2FA=@_2FA, Avatar=@Avatar, BaiViet=@BaiViet, \r\n                    Followers=@Followers, Following=@Following, TinhTrang=@TinhTrang, CheckPoin= @CheckPoin, Color=@Color, Mail=@Mail, Pass_Mail=@Pass_Mail, proxy=@proxy where Khoa_ID=@Khoa_ID";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("tjbii2ObfKo481+fL7claw==", "jnk7xxg"), thongtin.Khoa_ID));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("H/4qx0S9yes=", "jnk7xxg"), thongtin.User));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("iLc1i7pb4Ww=", "jnk7xxg"), thongtin.cookie));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("sXRPmXDvVWEnNbHBwEtecw==", "jnk7xxg"), thongtin.FullName));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("EeCsxKEYPNM=", "jnk7xxg"), thongtin.ID));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@_2FA", thongtin._2FA));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("N/T+tPPfTks=", "jnk7xxg"), thongtin.Avatar));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("lq1vh4yIGSc481+fL7claw==", "jnk7xxg"), thongtin.BaiViet));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("xTk5ihPGTUr7yBE1s6Wlvw==", "jnk7xxg"), thongtin.Followers));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("lrX6dGwK49eJ+5lAa5zKnA==", "jnk7xxg"), thongtin.Following));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("tqy9uCXHIWeJ+5lAa5zKnA==", "jnk7xxg"), thongtin.TinhTrang));
				sQLiteCommand.Parameters.Add(new SQLiteParameter("@CheckPoin", thongtin.CheckPoin));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("ZQp1n202Tkc=", "jnk7xxg"), thongtin.Color));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("eDOW4c/uxYo=", "jnk7xxg"), thongtin.Mail));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("DImhP/isLOgI/k0kdYiLqg==", "jnk7xxg"), thongtin.Pass_Mail));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("sCPy4CGUCaA=", "jnk7xxg"), thongtin.proxy));
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

		public void Update_Data_FB(ThongTin thongtin)
		{
			createConection();
			string commandText = "UPDATE tbl_acc_fb set proxy=@proxy, Cookie=@Cookie, Color=@Color, Row_Select=@Row_Select, checkselec=@checkselec where Khoa_ID=@Khoa_ID";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("Sfwkf22o9VcLaahiyxKNHQ==", "bpl8h"), thongtin.Khoa_ID));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("QyhZASdo+lk=", "bpl8h"), thongtin.proxy));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("BhrnyPw2/r8=", "bpl8h"), thongtin.cookie));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("mXoAqERrUGs=", "bpl8h"), thongtin.Color));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("Zh0hsClmY7CXqavxX2LNKg==", "bpl8h"), thongtin.Row_Select));
				sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DeCryptWithKey("OgSdfg0F75ZCSxCoKCKOqw==", "bpl8h"), thongtin.checkselec));
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

		public void _Update_Data(List<ThongTin> thongtin)
		{
			createConection();
			string commandText = "UPDATE tbl_acc set Cookie=@Cookie, FullName=@FullName, ID=@ID, _2FA=@_2FA, Avatar=@Avatar, BaiViet=@BaiViet, \r\n                    Followers=@Followers, Following=@Following, TinhTrang=@TinhTrang, CheckPoin=@CheckPoin, Color=@Color, checkselec=@checkselec, Row_Select=@Row_Select , Mail=@Mail, Pass_Mail=@Pass_Mail, proxy=@proxy\r\n                    where User=@User";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				foreach (ThongTin item in thongtin)
				{
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("QBAM17Ah5V4=", useHasing: true, "jcserx4"), item.User));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("VcdHJJfJeSU=", useHasing: true, "jcserx4"), item.cookie));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("3Zk/OaQvrr0zTxfJ7slcoQ==", useHasing: true, "jcserx4"), item.FullName));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("JfgZgMI0iYI=", useHasing: true, "jcserx4"), item.ID));
					sQLiteCommand.Parameters.Add(new SQLiteParameter("@_2FA", item._2FA));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("oD9UBaYEUFE=", useHasing: true, "jcserx4"), item.Avatar));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("Qujt+Ek6ilb30xd/zDNkxw==", useHasing: true, "jcserx4"), item.BaiViet));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("O+RpFwIafGVDPXBv1AyxAg==", useHasing: true, "jcserx4"), item.Followers));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("mGTmMYgZ6VFfz7nJHBOEhQ==", useHasing: true, "jcserx4"), item.Following));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("MWQla2nR1L5fz7nJHBOEhQ==", useHasing: true, "jcserx4"), item.TinhTrang));
					sQLiteCommand.Parameters.Add(new SQLiteParameter("@CheckPoin", item.CheckPoin));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("jNXVCSyaDLw=", useHasing: true, "jcserx4"), item.Color));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("TXLcqyIELspIq8f8XqSjXg==", useHasing: true, "jcserx4"), item.checkselec));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("dSDKDA0kcTrRxWxfg186nQ==", useHasing: true, "w1ztzwamjsq"), item.Row_Select));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("Fabk2yvRW4Q=", useHasing: true, "w1ztzwamjsq"), item.Mail));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("uo5eC2WO10mnYlpbYzfdOg==", useHasing: true, "w1ztzwamjsq"), item.Pass_Mail));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("oAeAiK3ioL0=", useHasing: true, "w1ztzwamjsq"), item.proxy));
					try
					{
						if (req._req != 0)
						{
							sQLiteCommand.ExecuteNonQuery();
						}
					}
					catch
					{
					}
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

		public void _Update_Data_FB(List<ThongTin> thongtin)
		{
			createConection();
			string commandText = "UPDATE tbl_acc_fb set proxy=@proxy, Cookie=@Cookie, Color=@Color, Row_Select=@Row_Select, checkselec=@checkselec where Khoa_ID=@Khoa_ID";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, _con))
			{
				using SQLiteTransaction sQLiteTransaction = _con.BeginTransaction();
				foreach (ThongTin item in thongtin)
				{
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("zyJWQbRjcV2ibODsaQDrbg==", useHasing: true, "smzrw1w9s2"), item.Khoa_ID));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("uwurEVDhcg0=", useHasing: true, "smzrw1w9s2"), item.proxy));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("eh3KRuBxjTE=", useHasing: true, "smzrw1w9s2"), item.cookie));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("firq+rRzSXY=", useHasing: true, "smzrw1w9s2"), item.Color));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("Fr0yCAYdtkhwUfNUDNZRzg==", useHasing: true, "smzrw1w9s2"), item.Row_Select));
					sQLiteCommand.Parameters.Add(new SQLiteParameter(Has.DecryptHas("26vyVQbm2sy3N39cV3Hd+Q==", useHasing: true, "smzrw1w9s2"), item.checkselec));
					try
					{
						if (req._req != 0)
						{
							sQLiteCommand.ExecuteNonQuery();
						}
					}
					catch
					{
					}
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

		public void Update_Data(string enum_thongtin, string Update_thongtin, string Khoa_ID)
		{
			createConection();
			Update_thongtin = Update_thongtin?.Replace("'", "''");
			string commandText = "UPDATE tbl_acc set " + enum_thongtin + "='" + Update_thongtin + "' where Khoa_ID='" + Khoa_ID + "'";
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

		public void Update_Data(string checkselec, string Row_Select)
		{
			createConection();
			string commandText = "UPDATE tbl_acc set " + enum_thongtin.checkselec.ToString() + "='" + checkselec + "', " + enum_thongtin.Row_Select.ToString() + "='" + Row_Select + "'";
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

		public void Update_Data_FB(string checkselec, string Row_Select)
		{
			createConection();
			string commandText = $"UPDATE tbl_acc_fb set {enum_thongtin.checkselec}='{checkselec}', {enum_thongtin.Row_Select}='{Row_Select}'";
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
