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
		public (string, byte[]) Encode(string text)
		{
			DESCryptoServiceProvider des = new();
			des.Mode = CipherMode.ECB;

			ICryptoTransform encryptor = des.CreateEncryptor();
			byte[] textBytes = Encoding.UTF8.GetBytes(text);
			byte[] encryptedBytes = encryptor.TransformFinalBlock(textBytes, 0, textBytes.Length);
			
			return (Convert.ToBase64String(encryptedBytes),des.Key);
		}

		public string Decode(string encryptedText, byte[] key)
		{
			DESCryptoServiceProvider des = new();
			des.Key = key;
			des.Mode = CipherMode.ECB;

			ICryptoTransform decryptor = des.CreateDecryptor();
			var encryptedBytes = Convert.FromBase64String(encryptedText);
			var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

			return Encoding.UTF8.GetString(decryptedBytes);
		}
	}
}
