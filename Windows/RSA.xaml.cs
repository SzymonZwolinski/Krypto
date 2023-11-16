using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp1.Windows
{
	/// <summary>
	/// Logika interakcji dla klasy RSA.xaml
	/// </summary>
	public partial class RSA : Window
	{
		private string PrivateKey = string.Empty; 
		private string PublicKey = string.Empty;
		private string CipheredText = string.Empty;
		public RSA(string privateKey, string publicKey, string cipheredText)
		{		
			InitializeComponent();
			PrivateKey = privateKey;
			PublicKey = publicKey;
			CipheredText = cipheredText;

			InitalizeUI();
		}

		private void InitalizeUI()
		{
			UpdatePublicKeyField();
			UpdatePrivateKeyField();
			UpdateCipheredTextField();
		}

		private void UpdatePublicKeyField()
		{
			PublicKeyField.Text = PublicKey;
		}

		private void UpdatePrivateKeyField()
		{
			PrivateKeyField.Text = PrivateKey;
		}

		private void UpdateCipheredTextField()
		{
			EncodedText.Text = CipheredText;
		}
	}
}
