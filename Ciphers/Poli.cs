using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public class Poli : IPoli
	{
		public string PolyalphabeticEncrypt(string input, string key)
		{
			var result = new StringBuilder();
			key = KeyFixer.InitalizeCorrectCoder(key, input.Length);

			for (var i = 0; i < input.Length; i++)
			{
				var currentChar = input[i];

				if (char.IsLetter(currentChar))
				{
					var keyIndex = i % key.Length;
					var shift = char.ToUpper(key[keyIndex]) - 'A';

					var encryptedChar = char.IsUpper(currentChar) ?
						(char)(((currentChar - 'A' + shift) % 26) + 'A') :
						(char)(((currentChar - 'a' + shift) % 26) + 'a');

					result.Append(encryptedChar);
				}
				else
				{
					result.Append(currentChar);
				}
			}

			return result.ToString();
		}

		public string PolyalphabeticDecrypt(string input, string key)
		{
			var result = new StringBuilder();
			key = KeyFixer.InitalizeCorrectCoder(key, input.Length);

			for (var i = 0; i < input.Length; i++)
			{
				var currentChar = input[i];

				if (char.IsLetter(currentChar))
				{
					var keyIndex = i % key.Length;
					var shift = char.ToUpper(key[keyIndex]) - 'A';

					var decryptedChar = char.IsUpper(currentChar) ?
						(char)(((currentChar - 'A' - shift + 26) % 26) + 'A') :
						(char)(((currentChar - 'a' - shift + 26) % 26) + 'a');

					result.Append(decryptedChar);
				}
				else
				{
					result.Append(currentChar);
				}
			}

			return result.ToString();
		}
	}
}
