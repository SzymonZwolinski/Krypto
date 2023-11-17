using System.Text;

namespace WpfApp1.Ciphers
{
	public class Poli : IPoli
	{
		public string PolyalphabeticEncrypt(string input, string key)
		{
			const int alphabetSize = 26;
			var result = new StringBuilder();
			key = KeyFixer.InitalizeCorrectCoder(key, input.Length);

			for (var i = 0; i < input.Length; i++)
			{
				var currentChar = input[i];
				var keyIndex = i % key.Length;
				var shift = char.ToUpper(key[keyIndex]) - 'A';

				if (char.IsLetter(currentChar))
				{
					var isUpperCase = char.IsUpper(currentChar);
					var baseChar = isUpperCase ? 'A' : 'a';
					var encryptedChar = (char)(((currentChar - baseChar + shift + alphabetSize) % alphabetSize) + baseChar);
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
			const int alphabetSize = 26;
			var result = new StringBuilder();
			key = KeyFixer.InitalizeCorrectCoder(key, input.Length);

			for (var i = 0; i < input.Length; i++)
			{
				var currentChar = input[i];
				var keyIndex = i % key.Length;
				var shift = char.ToUpper(key[keyIndex]) - 'A';

				if (char.IsLetter(currentChar))
				{
					var isUpperCase = char.IsUpper(currentChar);
					var baseChar = isUpperCase ? 'A' : 'a';
					var decryptedChar = (char)(((currentChar - baseChar - shift + alphabetSize) % alphabetSize) + baseChar);
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
