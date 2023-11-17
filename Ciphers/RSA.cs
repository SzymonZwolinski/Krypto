using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using WpfApp1.Helpers;

namespace WpfApp1.Ciphers
{
	public class RSA : IRSA
	{
		private const int blockSize = 128;
		private const int binBlockSize = 64;

		public (List<List<BigInteger>>, 
			Tuple<BigInteger, BigInteger>, 
			Tuple<BigInteger, BigInteger>) EncodeBitRsa(BigInteger input)
		{
			var keyPair = GenerateKeyPair();
			var publicKey = keyPair.Item1;
			var privateKey = keyPair.Item2;

			var n = publicKey.Item1;
			var e = publicKey.Item2;

			var blocks = new List<BigInteger>();
			var bitesAsString = input.ToString();
			for(var i = 0; i < bitesAsString.Length; i += binBlockSize)
			{
				if(bitesAsString.Length < binBlockSize)
				{
					bitesAsString = AddPaddingToBitArray(bitesAsString);
					blocks.Add(StringHelpers<string>.BinaryStringToBites(bitesAsString));
				}
				else
				{
					blocks.Add(StringHelpers<string>.BinaryStringToBites(bitesAsString.Substring(i, i + binBlockSize)));
				}

				bitesAsString.Remove(i, i + binBlockSize);
			}

			var encryptedBlocks = blocks.Select(x => BigInteger.ModPow(x, e, n)).ToList();

			var encryptedBlockLists = new List<List<BigInteger>>();
			foreach (var encryptedBlock in encryptedBlocks)
			{
				var singleBlockList = new List<BigInteger> { encryptedBlock };
				encryptedBlockLists.Add(singleBlockList);
			}

			return (
				encryptedBlockLists,
				publicKey, 
				privateKey);
		}


		public (List<List<BigInteger>>,
			Tuple<BigInteger, BigInteger>, 
			Tuple<BigInteger, BigInteger>) EncodeRSA(string input)
		{
			var keyPair = GenerateKeyPair();
			var publicKey = keyPair.Item1;
			var privateKey = keyPair.Item2;

			var n = publicKey.Item1;
			var e = publicKey.Item2;

			var blocks = input
				.Select((c, index) => new { Value = c, Index = index })
				.GroupBy(x => x.Index / (blockSize / 8))
				.Select(g => g.Select(x => x.Value).ToList())
				.ToList();

			var encryptedBlocks = blocks
				.Select(block =>
				block.Select(c =>
					BigInteger.ModPow(c, e, n))
					.ToList()) // c^e % n
				.ToList();

			return (encryptedBlocks, publicKey, privateKey);
		}

		public string Decrypt(List<List<BigInteger>> encryptedText, Tuple<BigInteger, BigInteger> privateKey)
		{
			var n = privateKey.Item1;
			var d = privateKey.Item2;

			var decryptedText = "";

			foreach (var encryptedList in encryptedText)
			{
				foreach (var c in encryptedList)
				{
					decryptedText += (char)BigInteger.ModPow(c, d, n);
				}
			}

			return decryptedText;
		}

		#region helpers
		private Tuple<Tuple<BigInteger, BigInteger>, Tuple<BigInteger, BigInteger>> GenerateKeyPair()
		{
			BigInteger p = 0, q = 0, n = 0;

			while (n < 128) // n musi byc większe lub równe podziałowi na bloki
			{
				while (!IsPrime(p))
				{
					p = GetRandomBigInteger(10);
				}
				while (!IsPrime(q) || q == p)
				{
					q = GetRandomBigInteger(10);
				}

				 n = p * q;
			}
			
			var phi = (p - 1) * (q - 1);

			var e = GetRandomExponent(phi);

			var d = ModInverse(e, phi);

			return Tuple.Create(Tuple.Create(n, e), Tuple.Create(n, d));
		}

		private bool IsPrime(BigInteger num)
		{
			if (num < 2)
				return false;
			for (var i = 2; i * i <= num; i++)
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
			bytes[bytes.Length - 1] &= (byte)0x7F; //upewnienie sie ze liczba zawsze jest nieujemna (And na ostatniej)
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

		private string AddPaddingToBitArray(string bites)
		{
			while (bites.Length != binBlockSize) 
			{
				bites += "0";
			}

			return bites;
		}
		#endregion
	}
}
