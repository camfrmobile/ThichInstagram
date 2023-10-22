using System.Runtime.InteropServices;
using System.Text;

namespace Interactive_ins
{
	public class iniFile
	{
		private string filePath;

		public string FilePath
		{
			get
			{
				return filePath;
			}
			set
			{
				filePath = value;
			}
		}

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public iniFile(string filePath)
		{
			this.filePath = filePath;
		}

		public void Write(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, filePath);
		}

		public string Read(string section, string key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int privateProfileString = GetPrivateProfileString(section, key, "", stringBuilder, 255, filePath);
			return stringBuilder.ToString();
		}
	}
}
