using System.Text;

namespace WpfApp1.Ciphers
{
	public class RC4 :IRC4
	{
		public string EncodeRC4(string key, string input)
		{
			var sbox = InitializeSBox(Encoding.UTF8.GetBytes(key));
			int i = 0;
			int j = 0;
			var result = new StringBuilder();

			for (int k = 0; k < input.Length; k++)
			{
				i = (i + 1) % 256;
				j = (j + sbox[i]) % 256;

				Swap(ref sbox[i], ref sbox[j]);

				int t = (sbox[i] + sbox[j]) % 256;

				char c = (char)(input[k] ^ sbox[t]);
				result.Append(c);
			}

			return result.ToString();
		}

		public string DecodeRC4(string key, string input)
		{
			// Decryption is the same as encryption
			return EncodeRC4(key, input);
		}

		private int[] InitializeSBox(byte[] key)
		{
			int[] sbox = new int[256];
			int keyLength = key.Length;

			for (int i = 0; i < 256; i++)
			{
				sbox[i] = i;
			}

			int j = 0;

			for (int i = 0; i < 256; i++)
			{
				j = (j + sbox[i] + key[i % keyLength]) % 256;
				Swap(ref sbox[i], ref sbox[j]);
			}

			return sbox;
		}

		private void Swap(ref int a, ref int b)
		{
			int temp = a;
			a = b;
			b = temp;
		}
	}
}
