using System;

namespace WpfApp1.Ciphers
{
	public static class KeyFixer
	{
		public static string InitalizeCorrectCoder(string key, int lengthOfTextToEncript)
		{
			if (key.Length == lengthOfTextToEncript)
			{
				return key;
			}

			if (key.Length > lengthOfTextToEncript)
			{
				throw new ArgumentOutOfRangeException("za długi klucz");
			}

			var i = 0;

			while (key.Length != lengthOfTextToEncript)
			{
				key += key[i];

				i++;
			}

			return key;
		}
	}
}
