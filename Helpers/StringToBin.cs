using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Helpers
{
	public static class StringToBin
	{
		public static byte[] BinaryStringToByteArray(string binaryString)
		{
			int numOfBytes = binaryString.Length / 8;
			byte[] byteArray = new byte[numOfBytes];

			for (int i = 0; i < numOfBytes; i++)
			{
				string byteString = binaryString.Substring(i * 8, 8);
				byteArray[i] = Convert.ToByte(byteString, 2);
			}

			return byteArray;
		}
	}
}
