using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace WpfApp1.Helpers
{
	public static class StringHelpers<T>
	{
		public static BigInteger BinaryStringToBites(string binaryString)
		{
			BigInteger result = BigInteger.Zero;
			try
			{
				result = BigInteger.Parse(binaryString);
			}
			catch { }

			return result;
		}

		public static byte[] HexStringToByteArray(string hex)
		{
			int numberChars = hex.Length;
			byte[] bytes = new byte[numberChars / 2];
			for (int i = 0; i < numberChars; i += 2)
			{
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return bytes;
		}

		public static string ConvertDoubleListToString(List<List<T>> listOfLists)
			=> string.Join(",", listOfLists.Select(block =>
				string.Join(",", block.Select(item => item.ToString()))));

		public static string TupleToString(Tuple<T, T> tuple)
			=> string.Join("", tuple);
	}
}
