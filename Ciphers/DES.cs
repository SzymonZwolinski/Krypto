using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;

namespace WpfApp1.Ciphers
{
	public class DES : IDES
	{
		public (string, byte[], byte[]) Encode(string text)
		{
			DESCryptoServiceProvider des = new();
			des.Mode = CipherMode.CBC;
			des.Padding = PaddingMode.PKCS7;
		
			ICryptoTransform encryptor = des.CreateEncryptor();
			var textBytes = Encoding.UTF8.GetBytes(text);
			var encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
			
			return (Convert.ToBase64String(encryptedBytes),des.Key, des.IV);
		}

		/*public string Decode(string encryptedText, byte[] key)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			des.Key = key;
			des.Mode = CipherMode.CBC;
			des.Padding = PaddingMode.PKCS7;
			
			ICryptoTransform decryptor = des.CreateDecryptor();
			var encryptedBytes = Convert.FromBase64String(encryptedText);
			var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

			return Encoding.UTF8.GetString(decryptedBytes);
		}*/

		public string Decode(string encryptedText, byte[] key, byte[] iv)
		{
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			des.Mode = CipherMode.CBC;
			des.Padding = PaddingMode.PKCS7;
			des.Key = key;
			des.IV = iv;

			ICryptoTransform decryptor = des.CreateDecryptor();
			var encryptedBytes = Convert.FromBase64String(encryptedText);
			var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

			return Encoding.UTF8.GetString(decryptedBytes);
		}
	}
}
