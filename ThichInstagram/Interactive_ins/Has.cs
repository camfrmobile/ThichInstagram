using System;
using System.Security.Cryptography;
using System.Text;

namespace Interactive_ins
{
	public class Has
	{
		public static string DecryptHas(string cypherString, bool useHasing, string key)
		{
			byte[] array = Convert.FromBase64String(cypherString);
			byte[] key2;
			if (useHasing)
			{
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				key2 = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
				mD5CryptoServiceProvider.Clear();
			}
			else
			{
				key2 = Encoding.UTF8.GetBytes(key);
			}
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key2;
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
			try
			{
				byte[] array2 = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
				tripleDESCryptoServiceProvider.Clear();
				if (!tt_kk._key.Contains(DeCryptWithKey("lxr4tQyPtlA=", "tg8fjqbatk")))
				{
					return DeCryptWithKey("07pRuhWz2bc=", "tg8fjqbatk");
				}
				return Encoding.UTF8.GetString(array2, 0, array2.Length);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static string DeCryptWithKey(string strDecypt, string key)
		{
			try
			{
				byte[] array = Convert.FromBase64String(strDecypt);
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] key2 = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
				TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
				tripleDESCryptoServiceProvider.Key = key2;
				tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
				tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
				ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor();
				byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
				return Encoding.UTF8.GetString(bytes);
			}
			catch (Exception)
			{
			}
			return "";
		}
	}
}
