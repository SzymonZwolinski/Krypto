using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface IMono
	{
		string MonoalphabeticEncrypt(string input, int key);
		string MonoalphabeticDecrypt(string input, int key);
	}
}
