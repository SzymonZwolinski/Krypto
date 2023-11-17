using System;
using System.Windows;
using WpfApp1.Ciphers;
using WpfApp1.Enums;

namespace WpfApp1
{
	/// <summary>
	/// Logika interakcji dla klasy ResultWindow.xaml
	/// </summary>
	public partial class ResultWindow : Window
	{
		private readonly IPoli _poli;
		private readonly IMono _mono;
		private readonly ITrans _trans;
		private readonly IRC4 _rc4;
		private readonly IServiceProvider _serviceProvider;

		private string CipheredText = string.Empty;
		private CipherTypes CipherType;
		private string MiddleStepText = string.Empty;
		private string PrivateKey;

		public ResultWindow(
			IPoli poli,
			IMono mono,
			ITrans trans,
			IRC4 rc4,
			IServiceProvider serviceProvider)
		{
			InitializeComponent();
			_poli = poli;
			_mono = mono;
			_trans = trans;
			_rc4 = rc4;
			_serviceProvider = serviceProvider;
		}

		public void InitalizeUi(string cipheredText, CipherTypes cipherType)
		{
			CipheredText = cipheredText;
			CipherType = cipherType;

			UpdateCipheredTextBox();
			UpdateCipheredTypeTextBox();
		}

		public void InitalizeDivider(string middleText)
		{
			MiddleStepText = middleText;
			UpdateMiddleStepBox();
		}

		public void AddPrivateKey(string privateKey)
		{
			PrivateKey = privateKey;
		}

		private void UpdateCipheredTextBox()
		{
			CipheredTextBox.Text = CipheredText;
		}

		private void UpdateCipheredTypeTextBox()
		{
			CIpheredTextType.Text = CipherType.ToString();
		}

		public void UpdateMiddleStepBox()
		{
			TryToInitalizeMiddleStepBoxes();
			MiddleStepBox.Text = MiddleStepText;

		}

		private void TryToInitalizeMiddleStepBoxes()
		{
			MiddleStepBorder.Visibility = Visibility.Visible;
			MiddleStepBox.Visibility = Visibility.Visible;
		}

		private void DecodeBttn_Click(object sender, RoutedEventArgs e)
		{
			string decodedText = string.Empty;
			switch(CipherType)
			{
				case (CipherTypes.Trans):
					decodedText = _trans.DecodeTransparent(CipheredText);
					break;
				case (CipherTypes.Mono):
					decodedText = _mono.MonoalphabeticDecrypt(CipheredText, int.Parse(PrivateKey));
					break;
				case (CipherTypes.Poli):
					decodedText = _poli.PolyalphabeticDecrypt(CipheredText, PrivateKey);
					break;
				case (CipherTypes.RC4):
					decodedText = _rc4.DecodeRC4(PrivateKey, CipheredText);
					break;
				default: 
					break;
			}

			CipheredText = decodedText;
			UpdateCipheredTextBox();
		}
	}
}
