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
using WpfApp1.Enums;

namespace WpfApp1
{
	/// <summary>
	/// Logika interakcji dla klasy ResultWindow.xaml
	/// </summary>
	public partial class ResultWindow : Window
	{
		private string CipheredText = string.Empty;
		private string CipherType = string.Empty;
		private string MiddleStepText = string.Empty;

		public ResultWindow(string cipheredText, CipherTypes cipherType, string? middleStepText)
		{
			InitializeComponent();
			CipheredText = cipheredText;
			CipherType = cipherType.ToString();
			MiddleStepText = middleStepText;


			UpdateCipheredTextBox();
			UpdateCipheredTypeTextBox();
			UpdateMiddleStepBox();
		}

		public ResultWindow(string cipheredText, CipherTypes cipherType)
		{
			InitializeComponent();
			
			CipheredText = cipheredText;
			CipherType = cipherType.ToString();

			if(cipherType == CipherTypes.Hamming)
			{
				HighlightHammingCorrectionCodes();
			}	

			UpdateCipheredTextBox();
			UpdateCipheredTypeTextBox();
		}

		private void UpdateCipheredTextBox()
		{
			CipheredTextBox.Text = CipheredText;
		}

		private void UpdateCipheredTypeTextBox()
		{
			CIpheredTextType.Text = CipherType;
		}

		private void UpdateMiddleStepBox()
		{
			TryToInitalizeMiddleStepBoxes();
			MiddleStepBox.Text = MiddleStepText;

		}

		private void TryToInitalizeMiddleStepBoxes()
		{
			MiddleStepBorder.Visibility = Visibility.Visible;
			MiddleStepBox.Visibility = Visibility.Visible;
		}

		private void HighlightHammingCorrectionCodes()
		{
			var lenOfText = CipheredText.Length;

			var reduntantBitsAmount = CalculateRedundantBits(lenOfText);

			/*for( int i = 0; i != reduntantBitsAmount; i++ ) 
			{
				CipheredText.Insert((lenOfText - i) + 1, "|");
				CipheredText.Insert((lenOfText - i) - 1, "|");
			}				*/	
		}

		private int CalculateRedundantBits(int m)
		{
			int r = 0;

			while (Math.Pow(2, r) <= m + r + 1)
			{
				r++;
			}

			return r;
		}
	}
}
