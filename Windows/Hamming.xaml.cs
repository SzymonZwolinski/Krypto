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
using WpfApp1.Ciphers;

namespace WpfApp1.Windows
{
	/// <summary>
	/// Logika interakcji dla klasy Hamming.xaml
	/// </summary>
	public partial class Hamming : Window
	{
		private readonly IHamming _hamming;
		private readonly IServiceProvider _serviceProvider;

		private string HammingCode;
		

		public Hamming(IHamming hamming, IServiceProvider serviceProvider)
		{
			InitializeComponent();
			_hamming = hamming;
			_serviceProvider = serviceProvider;
		}

		public void InitalizeUI(string text)
		{
			HammingCode = text;

			ChangeHammingTextBox(HammingCode);
			ChangeColourOfHammingRedundantBits();
		}

		private void ChangeHammingTextBox(string text)
		{
			hammingTextBox.Text = text;
		}

		private void ChangeColourOfHammingRedundantBits()
		{	
			var redundantBits = _hamming.CalculateRedundantBits(HammingCode.Length);

			for (int i = 0; i < HammingCode.Length; i++)
			{
				if ((i & (1 << redundantBits)) != 0)
				{
					hammingTextBox.Select(i, 1);
					hammingTextBox.Foreground = Brushes.Green;
				}
			}
		}

		private void ChangeColourOfDestroyedBit()
		{
			hammingTextBox.Select(0, 1);
			hammingTextBox.Foreground = Brushes.Red;
		}

		private void DecodeBtn_Click(object sender, RoutedEventArgs e)
		{
			HammingCode = _hamming.DecodeBinHamming(HammingCode);

			ChangeHammingTextBox(HammingCode);
        }

		private void Destroybtn_Click(object sender, RoutedEventArgs e)
		{
			HammingCode = _hamming.Destroyhamming(HammingCode);

			ChangeHammingTextBox(HammingCode);
			ChangeColourOfDestroyedBit();
		}
	}
}
