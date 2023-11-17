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

		public static string ConvertDoubleListToString(List<List<T>> listOfLists)
			=> string.Join(",", listOfLists.Select(block =>
				string.Join(",", block.Select(item => item.ToString()))));

		public static string TupleToString(Tuple<T, T> tuple)
			=> string.Join("", tuple);
	}
}
