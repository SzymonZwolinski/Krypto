using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Ciphers;
using WpfApp1.Helpers;

namespace WpfApp1.Windows
{
	/// <summary>
	/// Logika interakcji dla klasy RSA.xaml
	/// </summary>
	public partial class RSA : Window
	{
		private readonly IRSA _rsa;

		private readonly IServiceProvider _serviceProvider;

		private Tuple<BigInteger, BigInteger> PrivateKey;
		private Tuple<BigInteger, BigInteger> PublicKey;
		private List<List<BigInteger>> CipheredText;
		public RSA(IRSA rsa, IServiceProvider serviceProvider)
		{		
			InitializeComponent();
			_rsa = rsa;
		}

		public void InitalizeUI(
			Tuple<BigInteger, BigInteger> privateKey,
			Tuple<BigInteger, BigInteger> publicKey,
			 List<List<BigInteger>> cipheredText)
		{

			PrivateKey = privateKey;
			PublicKey = publicKey;
			CipheredText = cipheredText;

			UpdatePublicKeyField(StringHelpers<BigInteger>.TupleToString(PublicKey));
			UpdatePrivateKeyField(StringHelpers<BigInteger>.TupleToString(PrivateKey));
			UpdateCipheredTextField(StringHelpers<BigInteger>.ConvertDoubleListToString(CipheredText));
		}

		private void UpdatePublicKeyField(string text)
		{
			PublicKeyField.Text = text;
		}

		private void UpdatePrivateKeyField(string text)
		{
			PrivateKeyField.Text = text;
		}

		private void UpdateCipheredTextField(string text)
		{
			EncodedText.Text = text;
		}

		private void Decode(object sender, RoutedEventArgs e)
		{
			var decodedText = _rsa.Decrypt(CipheredText, PrivateKey);

			UpdateCipheredTextField(decodedText);
		}
	}
}
