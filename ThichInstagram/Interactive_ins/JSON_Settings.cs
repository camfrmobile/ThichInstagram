using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Interactive_ins
{
	public class JSON_Settings
	{
		private string PathFileSetting;

		private JObject json;

		public JSON_Settings(string jsonStringOrPathFile, bool isJsonString = false)
		{
			if (isJsonString)
			{
				if (jsonStringOrPathFile.Trim() == "")
				{
					jsonStringOrPathFile = "{}";
				}
				json = JObject.Parse(jsonStringOrPathFile);
				return;
			}
			try
			{
				if (jsonStringOrPathFile.Contains("\\") || jsonStringOrPathFile.Contains("/"))
				{
					PathFileSetting = jsonStringOrPathFile;
				}
				else
				{
					PathFileSetting = "settings\\" + jsonStringOrPathFile + ".json";
				}
				if (!File.Exists(PathFileSetting))
				{
					using (File.AppendText(PathFileSetting))
					{
					}
				}
				json = JObject.Parse(File.ReadAllText(PathFileSetting));
			}
			catch
			{
				json = new JObject();
			}
		}

		public JSON_Settings()
		{
			json = new JObject();
		}

		public string GetValue(string key, string valueDefault = "")
		{
			string result = valueDefault;
			try
			{
				result = ((json[key] == null) ? valueDefault : json[key]!.ToString());
			}
			catch
			{
			}
			return result;
		}

		public int GetValueInt(string key, int valueDefault = 0)
		{
			int result = valueDefault;
			try
			{
				result = ((json[key] == null) ? valueDefault : Convert.ToInt32(json[key]!.ToString()));
			}
			catch
			{
			}
			return result;
		}

		public bool GetValueBool(string key, bool valueDefault = false)
		{
			bool result = valueDefault;
			try
			{
				result = ((json[key] == null) ? valueDefault : Convert.ToBoolean(json[key]!.ToString()));
			}
			catch
			{
			}
			return result;
		}

		public void Add(string key, string value)
		{
			try
			{
				if (!json.ContainsKey(key))
				{
					json.Add(key, (JToken)value);
				}
				else
				{
					json[key] = (JToken)value;
				}
				Save();
			}
			catch (Exception)
			{
			}
		}

		public void Update(string key, object value)
		{
			try
			{
				json[key] = (JToken)value.ToString();
				Save();
			}
			catch
			{
			}
		}

		public void Update(string key, List<string> lst)
		{
			try
			{
				bool flag = false;
				foreach (string item in lst)
				{
					if (item.Contains("\n"))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					json[key] = (JToken)string.Join("\n|\n", lst).ToString();
				}
				else
				{
					json[key] = (JToken)string.Join("\n", lst).ToString();
				}
				Save();
			}
			catch
			{
			}
		}

		public void Remove(string key)
		{
			try
			{
				json.Remove(key);
				Save();
			}
			catch
			{
			}
		}

		public void Save()
		{
			try
			{
				if (tt_kk._key.Length == 17)
				{
					File.WriteAllText(PathFileSetting, json.ToString());
				}
			}
			catch
			{
			}
		}

		public string GetFullString()
		{
			string result = "";
			try
			{
				result = json.ToString().Replace("\r\n", "");
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
