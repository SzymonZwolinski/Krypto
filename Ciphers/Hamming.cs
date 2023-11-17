using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1.Ciphers
{
	public class Hamming : IHamming
	{
		public string EncodeBinHamming(BigInteger data)
		{
			int m = data.GetLength();
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
					encodedData[i] = StringHelpers<string>.BinaryStringToBites(data.ToString().Substring(j++, 0)) == 1 ? '1' : '0';
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
			var plainTextBin = 	StringHelpers<string>.BinaryStringToBites(input);

			return EncodeBinHamming(plainTextBin);
		}

		public string DecodeBinHamming(string encodedData)
		{
			int r = 0;
			while (Math.Pow(2, r) < encodedData.Length + r + 1)
			{
				r++;
			}

			int m = encodedData.Length - r;
			char[] decodedData = new char[m];
			int j = 0;

			for (int i = 0; i < m; i++)
			{
				if (!IsPowerOfTwo(i + 1))
				{
					decodedData[i] = encodedData[j++];
				}
			}

			for (int i = 0; i < r; i++)
			{
				int parityIndex = (int)Math.Pow(2, i) - 1;
				int sum = 0;

				for (int k = parityIndex; k < encodedData.Length; k += (int)Math.Pow(2, i + 1))
				{
					for (int l = 0; l < Math.Pow(2, i) && k + l < encodedData.Length; l++)
					{
						if (encodedData[k + l] == '1')
						{
							sum++;
						}
					}
				}

				if (sum % 2 != 0)
				{
					// Flip the bit to correct the error
					decodedData[parityIndex] = (decodedData[parityIndex] == '1') ? '0' : '1';
				}
			}

			return decodedData.ToString();
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

		private bool IsPowerOfTwo(int x)
		{
			return (x & (x - 1)) == 0 && x != 0;
		}
	}
}
