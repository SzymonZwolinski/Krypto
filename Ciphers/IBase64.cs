using System.Collections;
using System.Numerics;

namespace WpfApp1.Ciphers
{
	public interface IBase64
	{
		string ToBase64(string text);
		string BinToBase64(BigInteger binText);
	}
}
