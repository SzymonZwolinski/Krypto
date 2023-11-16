using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface IRSA
	{
		(List<List<BigInteger>>, Tuple<BigInteger, BigInteger>, Tuple<BigInteger, BigInteger>) EncodeRSA(string input);
		List<BigInteger> EncodeBitRsa(string input);
		string Decrypt(List<BigInteger> encryptedText, Tuple<BigInteger, BigInteger> privateKey);
	}
}
