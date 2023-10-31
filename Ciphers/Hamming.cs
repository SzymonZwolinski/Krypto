using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1.Ciphers
{
	public class Hamming : IHamming
	{
		public string EncodeBinHamming(string data)
		{
			int m = data.Length;
			int r = 0;
			while (Math.Pow(2, r) < m + r + 1)
			{
				r++;
			}

			char[] encodedData = new char[m + r];
			int j = 0;
			for (int i = 0; i < m + r; i++)
			{
				if (IsPowerOfTwo(i + 1))
				{
					encodedData[i] = '0';
				}
				else
				{
					encodedData[i] = data[j++];
				}
			}

			for (int i = 0; i < r; i++)
			{
				int parityIndex = (int)Math.Pow(2, i) - 1;
				int sum = 0;
				for (int k = parityIndex; k < m + r; k += (int)Math.Pow(2, i + 1))
				{
					for (int l = 0; l < Math.Pow(2, i) && k + l < m + r; l++)
					{
						if (encodedData[k + l] == '1')
						{
							sum++;
						}
					}
				}

				if (sum % 2 == 1)
				{
					encodedData[parityIndex] = '1';
				}
			}

			return new string(encodedData);
		}

		public string EncodeHamming(string input)
		{
			var plainTextBin = 	Encoding.ASCII.GetBytes(input);
			var binaryString = string.Join(" ", plainTextBin.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

			return EncodeBinHamming(binaryString);
		}

		private int CalculateRedundantBits(int m)
		{
			//2^r ≥ m + r + 1
			int r = 0;

			while (Math.Pow(2, r) <= m + r + 1)
			{
				r++;
			}

			return r;
		}

		public static bool IsPowerOfTwo(int n)
		{
			return (n & (n - 1)) == 0 && n != 0;
		}
	}
}
