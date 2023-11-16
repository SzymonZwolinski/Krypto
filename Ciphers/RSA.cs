using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1.Ciphers
{
	public class RSA : IRSA
	{
		public List<BigInteger> EncodeBitRsa(string input)
		{
			var keyPair = GenerateKeyPair();
			var publicKey = keyPair.Item1;
			var privateKey = keyPair.Item2;

			var n = publicKey.Item1;
			var e = publicKey.Item2;

			List<BigInteger> encryptedText = input.Select(c => BigInteger.ModPow(c, e, n)).ToList();
			return encryptedText;
		}

		public (List<List<BigInteger>>, Tuple<BigInteger, BigInteger>, Tuple<BigInteger, BigInteger>) EncodeRSA(string input)
		{
			var keyPair = GenerateKeyPair();
			var publicKey = keyPair.Item1;
			var privateKey = keyPair.Item2;

			var n = publicKey.Item1;
			var e = publicKey.Item2;

			var blockSize = 128; // Długość bloku w bitach
			var blocks = input
				.Select((c, index) => new { Value = c, Index = index })
				.GroupBy(x => x.Index / (blockSize / 8))
				.Select(g => g.Select(x => x.Value).ToList())
				.ToList();

			var encryptedBlocks = blocks
				.Select(block => block.Select(c => BigInteger.ModPow(c, e, n)).ToList())
				.ToList();

			return (encryptedBlocks, publicKey, privateKey);
		}

		public string Decrypt(List<BigInteger> encryptedText, Tuple<BigInteger, BigInteger> privateKey)
		{
			var n = privateKey.Item1;
			var d = privateKey.Item2;

			var decryptedText = new string(encryptedText.Select(c => (char)BigInteger.ModPow(c, d, n)).ToArray());

			return decryptedText;
		}
		#region helpers
		private Tuple<Tuple<BigInteger, BigInteger>, Tuple<BigInteger, BigInteger>> GenerateKeyPair()
		{
			BigInteger p = 0, q = 0;

			while (!IsPrime(p))
			{
				p = GetRandomBigInteger(10);
			}
			while (!IsPrime(q) || q == p)
			{
				q = GetRandomBigInteger(10);
			}

			var n = p * q;
			var phi = (p - 1) * (q - 1);

			var e = GetRandomExponent(phi);

			var d = ModInverse(e, phi);

			return Tuple.Create(Tuple.Create(n, e), Tuple.Create(n, d));
		}

		private bool IsPrime(BigInteger num)
		{
			if (num < 2)
				return false;
			for (BigInteger i = 2; i * i <= num; i++)
			{
				if (num % i == 0)
					return false;
			}
			return true;
		}

		private BigInteger GetRandomBigInteger(int bitLength)
		{
			var random = new Random();
			var bytes = new byte[bitLength / 8];
			random.NextBytes(bytes);
			bytes[bytes.Length - 1] &= (byte)0x7F; 
			return new BigInteger(bytes);
		}

		private BigInteger GetRandomExponent(BigInteger max)
		{
			var random = new Random();
			BigInteger result;
			do
			{
				result = GetRandomBigInteger((int)max.ToByteArray().Length * 8);
			} while (result >= max || result <= 1 || BigInteger.GreatestCommonDivisor(result, max) != 1);
			return result;
		}

		private BigInteger ModInverse(BigInteger a, BigInteger m)
		{
			var m0 = m;

			BigInteger x0 = 0;
			BigInteger x1 = 1;

			while (a > 1)
			{
				BigInteger q = a / m;
				BigInteger t = m;

				m = a % m;
				a = t;
				t = x0;

				x0 = x1 - q * x0;
				x1 = t;
			}

			if (x1 < 0)
			{
				x1 += m0;
			}

			return x1;


		}

		#endregion
	}
}
