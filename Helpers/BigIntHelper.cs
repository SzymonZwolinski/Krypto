using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Helpers
{
	public static class BigIntHelper
	{
		public static int GetLength(this BigInteger x)
			=> (int)Math.Floor(BigInteger.Log10(x) + 1);
	}
}
