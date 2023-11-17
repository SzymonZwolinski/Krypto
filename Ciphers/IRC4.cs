using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface IRC4
	{
		string EncodeRC4(string key, string input);
		string DecodeRC4(string key, string input);
	}
}
