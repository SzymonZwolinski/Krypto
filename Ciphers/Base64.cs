using System.Text;
using System;
using System.Collections;
using WpfApp1.Helpers;
using System.Numerics;

namespace WpfApp1.Ciphers
{
	public class Base64 : IBase64
	{
		private const string Base64Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

		public string BinToBase64(BigInteger binText)
		{
			var base64StringBuilder = new StringBuilder();

			var binString = binText.ToString();

			var padding = 8 - binString.Length % 8;
			binString = new string('0', padding) + binString;

			for (var i = 0; i < binString.Length; i += 6)
			{
				var groupSize = Math.Min(6, binString.Length - i);

				var value = Convert.ToInt32(binString.Substring(i, groupSize), 2);

				base64StringBuilder.Append(Base64Characters[value]);
			}

			return base64StringBuilder.ToString();
		}



		public string ToBase64(string text)
		{
			var plainTextBytes = StringHelpers<string>.BinaryStringToBites(text);

			return BinToBase64(plainTextBytes);
		}
	}
}
