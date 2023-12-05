using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface IDES
	{
		(string, byte[], byte[]) Encode(string text);
		string Decode(string encryptedText, byte[] key, byte[] iv);
	}
}
