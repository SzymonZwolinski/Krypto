using System.Text;
using System;

namespace WpfApp1.Ciphers
{
	public class Base64 : IBase64
	{
		private const string Base64Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

		public string BinToBase64(byte[] binText)
		{
			var base64StringBuilder = new StringBuilder();

			for (int i = 0; i < binText.Length; i += 3)
			{
				int groupSize = Math.Min(3, binText.Length - i);
				int byte1 = binText[i];
				int byte2 = groupSize > 1 ? binText[i + 1] : 0;
				int byte3 = groupSize > 2 ? binText[i + 2] : 0;

				int char1 = byte1 >> 2;
				int char2 = ((byte1 & 3) << 4) | (byte2 >> 4);
				int char3 = ((byte2 & 15) << 2) | (byte3 >> 6);
				int char4 = byte3 & 63;

				base64StringBuilder.Append(Base64Characters[char1]);
				base64StringBuilder.Append(Base64Characters[char2]);
				base64StringBuilder.Append(groupSize > 1 ? Base64Characters[char3] : '=');
				base64StringBuilder.Append(groupSize > 2 ? Base64Characters[char4] : '=');
			}

			return base64StringBuilder.ToString();
		}

		public string ToBase64(string text)
		{
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);

			return BinToBase64(plainTextBytes);
		}
	}
}
