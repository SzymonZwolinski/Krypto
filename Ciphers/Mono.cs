using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public class Mono : IMono
	{
		public string MonoalphabeticEncrypt(string input, int key)
		{
			var result = new StringBuilder();

			foreach (char c in input)
			{
				result.Append((char)((int)c + key));
			}

			return result.ToString();
		}

		public string MonoalphabeticDecrypt(string input, int key)
		{
			var result = new StringBuilder();

			foreach (char c in input)
			{
				result.Append((char)((int)c - key));
			}

			return result.ToString();
		}
	}
}
