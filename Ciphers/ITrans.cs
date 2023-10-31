using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface ITrans
	{
		(string, string) TransparentEncription(string sentence);
		string DecodeTransparent(string sentence);
	}
}
