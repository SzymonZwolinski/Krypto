namespace WpfApp1.Ciphers
{
	public interface IPoli
	{
		string PolyalphabeticEncrypt(string input, string key);
		string PolyalphabeticDecrypt(string input, string key);
	}
}
