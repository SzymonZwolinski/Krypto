using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface IRSA
	{
		(List<List<BigInteger>>,
		Tuple<BigInteger, BigInteger>,
		Tuple<BigInteger, BigInteger>) EncodeRSA(string input);

		(List<List<BigInteger>>,
		Tuple<BigInteger, BigInteger>,
		Tuple<BigInteger, BigInteger>) EncodeBitRsa(BigInteger input);

		string Decrypt(
			List<List<BigInteger>> encryptedText, 
			Tuple<BigInteger, BigInteger> privateKey);
	}
}
