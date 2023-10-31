using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Ciphers
{
	public interface IHamming
	{
		string EncodeHamming(string input);
		string EncodeBinHamming(string input);
	}
}
